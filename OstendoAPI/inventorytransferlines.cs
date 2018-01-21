using System;
using System.Collections.Generic;
using System.Text;

namespace OstendoAPI
{
    public class inventorytransferlines
    {
        //public double sysuniqueid { get; set; }
        //public double inventorysysuniqueid { get; set; }
        public string batchno { get; set; }
        public string itemgrade { get; set; }

        // REQUIRED SYSTEM FIELDS
        public int transferno { get; set; }
        public string itemcode { get; set; }
        public string unit { get; set; }
        public string fromwarehouse { get; set; }
        public string towarehouse { get; set; }
        public string fromlocation { get; set; }
        public string tolocation { get; set; }
        public double transferqty { get; set; }





        // --- --- --- --- --- --- --- --- --- --- --- --- //
        //Field:	TRANSFERNO Type:	INTEGER
        //Field:	ITEMCODE Type:	VARCHAR Length: 50
        //Field:	UNIT Type:	VARCHAR Length: 15
        //Field:	FROMWAREHOUSE Type:	VARCHAR Length: 20
        //Field:	TOWAREHOUSE Type:	VARCHAR Length: 20
        //Field:	FROMLOCATION Type:	VARCHAR Length: 20
        //Field:	TOLOCATION Type:	VARCHAR Length: 20
        //Field:	INTRANSITQTY Type:	DOUBLE
        //Field:	TRANSFERQTY Type:	DOUBLE
        //Field:	SERIALNO Type:	VARCHAR Length: 30
        //Field:	EXPIRYDATE Type:	DATE
        //Field:	BATCHNO Type:	VARCHAR Length: 50
        //Field:	REVISIONNO Type:	VARCHAR Length: 10
        //Field:	ITEMGRADE Type:	VARCHAR Length: 50
        //Field:	ITEMCOLOUR Type:	VARCHAR Length: 50
        //Field:	ITEMSIZE Type:	VARCHAR Length: 50
        //Field:	CHARGEVALUE Type:	DOUBLE
        //Field:	TRANSFERCOST Type:	DOUBLE
        //Field:	INVENTORYSYSUNIQUEID Type:	DOUBLE
        //Field:	INVENTORYONHANDQTY Type:	DOUBLE
        //Field:	HEADERSYSUNIQUEID Type:	DOUBLE
        //Field:	SYSDATECREATED Type:	TIMESTAMP
        //Field:	SYSDATEMODIFIED Type:	TIMESTAMP
        //Field:	SYSUNIQUEID Type:	DOUBLE
        //Field:	SYSUSERCREATED Type:	VARCHAR Length: 30
        //Field:	SYSUSERMODIFIED Type:	VARCHAR Length: 30


    }
}
