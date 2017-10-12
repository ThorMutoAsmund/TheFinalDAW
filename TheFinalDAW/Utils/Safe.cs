using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalDAW.Utils
{
    public struct Safe<T> where T : class
    {
        private readonly T value;

        public Safe(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            this.value = value;
        }   

        public T Value
        {
            get
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                return value;
            }
        }

        public static implicit operator Safe<T>(T value)
        {
            return new Safe<T>(value);
        }

        public static implicit operator T(Safe<T> wrapper)
        {
            return wrapper.Value;
        }
    }
}
