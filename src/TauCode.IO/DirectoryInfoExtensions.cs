using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TauCode.IO
{
    public static class DirectoryInfoExtensions
    {
        public static void Purge(this DirectoryInfo directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (var dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
