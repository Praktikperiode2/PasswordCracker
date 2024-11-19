using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCracker
{
    public class Counter
    {
        private int count;

        public void Increment()
        {
            Interlocked.Increment(ref count);
        }

        public int GetTotal()
        {
            return count;
        }
    }

}
