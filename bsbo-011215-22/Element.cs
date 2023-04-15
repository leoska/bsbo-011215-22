using System;
namespace bsbo_011215_22
{
	public class Element
	{
		public int value = 0;
		public Element? next = null;

        public Element(int value = 0, Element? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }
}

