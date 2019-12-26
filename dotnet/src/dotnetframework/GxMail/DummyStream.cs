﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GeneXus.Mail
{
    public class DummyStream: Stream
    {
        public override void Write(byte[] buffer, int offset, int count)
        {            
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            
        }

        public override long Length
        {
            get { return 0; }
        }

        public override long Position
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }

        public override void SetLength(long value)
        {           
        }
    }
}
