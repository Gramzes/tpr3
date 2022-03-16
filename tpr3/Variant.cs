using System;
using System.Collections.Generic;
using System.Text;

namespace tpr3
{
    class Variant
    {
        public bool inList = true;
        public int Price;
        public int ProcTopPlace;
        public int CameraTopPlace;

        public Variant(int Price, int ProcTopPlace, int CameraTopPlace)
        {
            this.Price = Price;
            this.ProcTopPlace = ProcTopPlace;
            this.CameraTopPlace = CameraTopPlace;
        }
        static public bool operator >(Variant variant1, Variant variant2)
        {
            if (variant1.Price < variant2.Price && variant1.ProcTopPlace < variant2.ProcTopPlace && variant1.CameraTopPlace < variant2.CameraTopPlace) return true;
            return false;
        }
        static public bool operator <(Variant variant1, Variant variant2)
        {
            if (variant1.Price > variant2.Price && variant1.ProcTopPlace > variant2.ProcTopPlace && variant1.CameraTopPlace > variant2.CameraTopPlace) return true;
            return false;
        }
        static public bool operator ==(Variant variant1, Variant variant2)
        {
            if (variant1.Price == variant2.Price && variant1.ProcTopPlace == variant2.ProcTopPlace && variant1.CameraTopPlace == variant2.CameraTopPlace) return true;
            return false;
        }
        static public bool operator !=(Variant variant1, Variant variant2)
        {
            return !(variant1 == variant2);
        }
    }
}
