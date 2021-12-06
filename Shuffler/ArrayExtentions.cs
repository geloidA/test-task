using System;

namespace Shuffler
{
    public static class ArrayExtentions
    {
        public static Array CreateCopy(this Array array, int startIndex, int length)
        {
            var arrayCopy = Array.CreateInstance(typeof(object), length);
            Array.Copy(array, startIndex, arrayCopy, 0, length);
            return arrayCopy;
        }
    }
}
