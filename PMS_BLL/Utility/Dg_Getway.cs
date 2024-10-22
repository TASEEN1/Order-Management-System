namespace PMS_BLL.Utility
{
    public class Dg_Getway
    {
        private static string _dg_pms;
        private static string _SpecFoCon;
        private static string _SpecFoInventory;
        private static string _Mr_SCM;
        private static string _dg_barcode;
        private static string _dg_smart_code;
        private static string _dg_gate_pass;
        private static string _dg_weaving;
        private static string _dg_Asst_Mgt;
        private static string _dg_Oder_Mgt;

        public static string PmsCon
        {
            get
            {
                if (_dg_pms == null)
                {
                    //_dg_pms = String.Format("Data Source=.;Initial Catalog=Mr_PMS;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_pms = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_PMS;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                    //_dg_pms = String.Format("Data Source=192.168.1.42;Initial Catalog=Mr_PMS;Persist Security Info=true; User ID=sa; Password=--------;TrustServerCertificate=True");

                }
                return _dg_pms;
            }
        }
        public static string SpecFoCon
        {
            get
            {
                if (_SpecFoCon == null)
                {
                    //_SpecFoCon = String.Format("Data Source=.;Initial Catalog=SpecFo;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _SpecFoCon = String.Format("Data Source=192.168.100.250;Initial Catalog=SpecFo;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                    //_SpecFoCon = String.Format("Data Source=192.168.1.42;Initial Catalog=SpecFo;Persist Security Info=true; User ID=sa; Password=-------;TrustServerCertificate=True");

                }
                return _SpecFoCon;
            }
        }

        

        public static string Mr_SCM
        {
            get
            {
                if (_Mr_SCM == null)
                {
                    //_Mr_SCM = String.Format("Data Source=.;Initial Catalog=Mr_SCM;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _Mr_SCM = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_SCM;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _Mr_SCM;
            }
        }

        public static string dg_barcode
        {
            get
            {
                if (_dg_barcode == null)
                {
                    //_dg_barcode = String.Format("Data Source=.;Initial Catalog=Barcoding;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_barcode = String.Format("Data Source=192.168.100.250;Initial Catalog=Barcoding;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _dg_barcode;
            }
        }

        public static string dg_smart_code
        {
            get
            {
                if (_dg_smart_code == null)
                {
                    //_dg_smart_code = String.Format("Data Source=192.168.100.250;Initial Catalog=Smartcode;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_smart_code = String.Format("Data Source=192.168.100.250;Initial Catalog=Smartcode;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _dg_smart_code;
            }
        }

        public static string dg_gate_pass
        {
            get
            {
                if (_dg_gate_pass == null)
                {
                    //_dg_gate_pass = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_Gate_Pass_Sys;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_gate_pass = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_Gate_Pass_Sys;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _dg_gate_pass;
            }
        }

        public static string dg_weaving
        {
            get
            {
                if (_dg_weaving == null)
                {
                    //_dg_weaving = String.Format("Data Source=192.168.100.250;Initial Catalog=dg_textile;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_weaving = String.Format("Data Source=192.168.100.250;Initial Catalog=dg_textile;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _dg_weaving;
            }


        }
      

        public static string dg_Asst_Mgt
        {
            get
            {
                if (_dg_Asst_Mgt == null)
                {
                    _dg_Asst_Mgt = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_Asset_Info;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    //_dg_Asst_Mgt = String.Format("Data Source=192.168.100.250;Initial Catalog=Mr_Asset_Info;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                }
                return _dg_Asst_Mgt;
            }
        }

       
        public static string SpecFoInventory
        {
            get
            {
                if (_SpecFoInventory == null)
                {
                    //_SpecFoInventory = String.Format("Data Source=192.168.100.250;Initial Catalog=SpecFo_Inventory;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _SpecFoInventory = String.Format("Data Source=192.168.100.250;Initial Catalog=SpecFo_Inventory;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                    //_SpecFoInventory = String.Format("Data Source=192.168.1.42;Initial Catalog=SpecFo_Inventory;Persist Security Info=true; User ID=sa; Password=-------;TrustServerCertificate=True");

                }
                return _SpecFoInventory;
            }
        }



      
        public static string dg_Oder_Mgt
        {

            get
            {
                if (_dg_Oder_Mgt == null)
                {
                    //_dg_Oder_Mgt = String.Format("Data Source=.;Initial Catalog=dg_OMS;Persist Security Info=true; User ID=sa; Password=taseen;TrustServerCertificate=True");
                    _dg_Oder_Mgt = String.Format("Data Source=192.168.100.250;Initial Catalog=dg_OMS;Persist Security Info=true; User ID=sa; Password=dg@INFO;TrustServerCertificate=True");
                    // _dg_Oder_Mgt = String.Format("Data Source=192.168.1.42;Initial Catalog=dg_OMS;Persist Security Info=true; User ID=sa; Password=--------;TrustServerCertificate=True");

                }
                return _dg_Oder_Mgt;
            }
        }

        
    }
}
