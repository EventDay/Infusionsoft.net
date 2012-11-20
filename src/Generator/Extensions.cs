using System;
using System.IO;

namespace Generator
{
    public static class Extensions
    {
        public static DirectoryInfo Directory(this string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            return new DirectoryInfo(path);
        }
    }
}