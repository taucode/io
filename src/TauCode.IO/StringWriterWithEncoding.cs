﻿using System;
using System.IO;
using System.Text;

// todo move to taucode.io
namespace TauCode.IO
{
    public sealed class StringWriterWithEncoding : StringWriter
    {
        public StringWriterWithEncoding()
            : this(Encoding.UTF8)
        {
        }

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        public override Encoding Encoding { get; }
    }
}
