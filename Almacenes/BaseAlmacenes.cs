using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TUTASAPrototipo.Almacenes
{
    public interface IAlmacenLectura<T, TKey>
    {
        IEnumerable<T> Todos { get; }
        int Cantidad { get; }
        bool TryObtener(TKey clave, out T valor);
        IEnumerable<T> Buscar(Predicate<T> predicado);
    }

    public interface IAlmacen<T, TKey> : IAlmacenLectura<T, TKey>
    {
        bool Agregar(T item);
        void Upsert(T item);
        bool Eliminar(TKey clave);
        void Limpiar();
    }

    // Almacén genérico en memoria con clave
    public class AlmacenEnMemoria<T, TKey> : IAlmacen<T, TKey>
        where TKey : notnull
    {
        private readonly ConcurrentDictionary<TKey, T> _mapa;
        private readonly Func<T, TKey> _selectorClave;

        public AlmacenEnMemoria(Func<T, TKey> selectorClave, IEqualityComparer<TKey>? comparador = null)
        {
            _selectorClave = selectorClave ?? throw new ArgumentNullException(nameof(selectorClave));
            _mapa = new ConcurrentDictionary<TKey, T>(comparador ?? EqualityComparer<TKey>.Default);
        }

        public IEnumerable<T> Todos => _mapa.Values.ToArray();

        public int Cantidad => _mapa.Count;

        public bool TryObtener(TKey clave, out T valor) => _mapa.TryGetValue(clave, out valor!);

        public IEnumerable<T> Buscar(Predicate<T> predicado)
        {
            if (predicado is null) throw new ArgumentNullException(nameof(predicado));
            return _mapa.Values.Where(v => predicado(v)).ToArray();
        }

        public bool Agregar(T item)
        {
            var clave = _selectorClave(item);
            return _mapa.TryAdd(clave, item);
        }

        public void Upsert(T item)
        {
            var clave = _selectorClave(item);
            _mapa.AddOrUpdate(clave, item, (_, _) => item);
        }

        public bool Eliminar(TKey clave) => _mapa.TryRemove(clave, out _);

        public void Limpiar() => _mapa.Clear();
    }

    // Almacén en memoria sin clave (lista)
    public interface IAlmacenListaLectura<T>
    {
        IEnumerable<T> Todos();
        int Cantidad { get; }
        IEnumerable<T> Buscar(Predicate<T> predicado);
    }

    public interface IAlmacenLista<T> : IAlmacenListaLectura<T>
    {
        void Agregar(T item);
        int EliminarDonde(Predicate<T> predicado);
        void Limpiar();
    }

    public class AlmacenListaEnMemoria<T> : IAlmacenLista<T>
    {
        private readonly List<T> _items = new();
        private readonly object _sync = new();

        public int Cantidad
        {
            get { lock (_sync) return _items.Count; }
        }

        public IEnumerable<T> Todos()
        {
            lock (_sync) return _items.ToArray();
        }

        public void Agregar(T item)
        {
            lock (_sync) _items.Add(item);
        }

        public int EliminarDonde(Predicate<T> predicado)
        {
            lock (_sync) return _items.RemoveAll(predicado);
        }

        public IEnumerable<T> Buscar(Predicate<T> predicado)
        {
            lock (_sync) return _items.Where(x => predicado(x)).ToArray();
        }

        public void Limpiar()
        {
            lock (_sync) _items.Clear();
        }
    }
}
