using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OstendoAPI
{
    public class inventorytransfers
    {
        public int transferno { get; set; }
        public string transferreference { get; set; }
        //public string TRANSFERSTATUS { get; set; }
        //public DateTime TRANSFERDATE { get; set; }
        //public string TRANSFERNOTES { get; set; }
        //public bool TRANSFERCHARGE { get; set; }
        //public string CHARGECODE { get; set; }
        //public string CHARGECAPTION { get; set; }
        public string allocationmethod { get; set; }
        //public string CHARGECOSTCENTRE { get; set; }
        //public double CHARGEAMOUNT { get; set; }
        public string transferstyle { get; set; }
        //public string FROMSITE { get; set; }
        //public string TOSITE { get; set; }
        //public string CREATEFROM { get; set; }
        //public DateTime REQUIREDDATE { get; set; }
        //public DateTime SYSDATEMODIFIED { get; set; }
        //public DateTime SYSDATECREATED { get; set; }
        //public double SYSUNIQUEID { get; set; }
        //public string SYSUSERCREATED { get; set; }
        //public string SYSUSERMODIFIED { get; set; }

        /*
         * 
         * <inventorytransfers>
                        <transferno>8662</transferno>
                        <transferreference>{TEST02} DRYBLEND TRANSFER</transferreference>
                        <transferstatus>Updated</transferstatus>
                        <transferdate>19/01/2018</transferdate>
                        <transfercharge>0</transfercharge>
                        <allocationmethod>Quantity</allocationmethod>
                        <transferstyle>Location Transfer</transferstyle>
                        <createfrom>Manual</createfrom>
                        <sysdatecreated>19/01/2018 3:43:27 p.m.</sysdatecreated>
                        <sysdatemodified>19/01/2018 3:46:15 p.m.</sysdatemodified>
                        <sysuniqueid>4515954</sysuniqueid>
                        <sysusercreated>ADMIN</sysusercreated>
                        <sysusermodified>ADMIN</sysusermodified>
                </inventorytransfers>

                <?xml version="1.0"?><InventoryTransfers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><TRANSFERNO>0</TRANSFERNO><TRANSFERREFERENCE>TEST03 DRYBLEND TRANSFER</TRANSFERREFERENCE><TRANSFERDATE>2018-01-19T00:00:00+13:00</TRANSFERDATE><TRANSFERCHARGE>false</TRANSFERCHARGE><ALLOCATIONMETHOD>Quantity</ALLOCATIONMETHOD><CHARGEAMOUNT>0</CHARGEAMOUNT><TRANSFERSTYLE>Location Transfer</TRANSFERSTYLE><CREATEFROM>Manual</CREATEFROM><REQUIREDDATE>0001-01-01T00:00:00</REQUIREDDATE><SYSDATEMODIFIED>0001-01-01T00:00:00</SYSDATEMODIFIED><SYSDATECREATED>0001-01-01T00:00:00</SYSDATECREATED><SYSUNIQUEID>0</SYSUNIQUEID></InventoryTransfers>
        */

    }
}
