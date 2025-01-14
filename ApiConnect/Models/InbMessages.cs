﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConnect.Models
{
    public class PACK_COMPLETE
    {
        public string companyId;
        public string sellerId;               // vendor/seller for 3PL
        public string facilityId;
        public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode;
        public string messageDesc;
        public string waveId;
        public string orderId;
        public string containerBarCode;
        public string shipVia;
        public string shipTo;
        public string shipCarrier;
        public string carrierTrackingId;
        public string customerId;
        public string message_ts;
    }

    public class LINE_DETAIL
    {
        //public string companyId;
        // public string sellerId;
        // public string facilityId;
        // public string messageNumber;      // actually NUMERIC (ulong) but string for now (for ease of use)
        // public string messageCode;
        // public string messageDesc;
        //  public string waveId;
        public string orderId;
        public string batchId;
        public string containerBarCode;
        public string lineItemId;
        public string wmsLocationId;
        public string wmsContainerId;
        public string wmsPickZone;
        public string sku;
        public string skuDesc;
        public string requestedQty;       // actually NUMERIC (ulong) but string for now (for ease of use)
        public string actualQty;          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string hazmat;
        public string productCode;
        public string aggregatedWeight;   // actually NUMERIC (ulong) but string for now (for ease of use)
        public string unitWeight;         // actually NUMERIC (ulong) but string for now (for ease of use)
        public string user;
        // public string message_ts;
        public LINE_DETAIL()
        {

            // messageCode = "2006";
            // messageDesc = "LINE_DETAIL";

        }
    }
    public class WAVE_HEADER
    {
        public string companyId;
        public string sellerId;
        public string facilityId;
        public string messageNumber;      // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode;
        public string messageDesc;
        public string waveId;
        public string waveType;
        public string priority;           // actually NUMERIC (ulong) but string for now (for ease of use)
        public string action;
        public string activate;
        public string message_ts;
        public WAVE_HEADER()
        {

            messageCode = "2001";
            messageDesc = "WAVE_HEADER";

        }
    }




    public class ORDER_HEADER
    {
        //public string companyId;
        public string sellerId;               // vendor/seller for 3PL
                                              //public string facilityId;
                                              //public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
                                              // public string messageCode;
                                              //public string messageDesc;
                                              //public string waveId;
        public string orderId;
        public string orderType;
        public string orderCategory;
        public string customerId;
        public string parcel;
        public string productSellerId;        // not used (remove)
        public string countryCode;
        public string hazmat;
        public string shipVia;
        public string shipTo;
        public string carrier;
        public string priority;               // actually NUMERIC (ulong) but string for now (for ease of use)
        public string vasCode;
        public string action;
        public string activate;
        public string containerCount;
        public string detailCount;
        // public string message_ts;
        public ORDER_HEADER()
        {

            //messageCode = "2003";
            // messageDesc = "ORDER_HEADER";

        }
    }

    public class CONT_HEADER
    {
        // public string companyId;
        // public string sellerId;               // vendor/seller for 3PL
        // public string facilityId;
        // public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
        // public string messageCode;
        // public string messageDesc;
        // public string waveId;
        public string orderId;
        public string batchId;
        public string unitSortZone;
        public string user;
        public string containerBarCode;
        public string wmsContainerId;
        public string wmsContainerType;
        public string audit;
        public string carrier;
        public string priority;               // actually NUMERIC (ulong) but string for now (for ease of use)
        public string vasCode;
        public string action;
        public string activate;
        //public string message_ts;
        public CONT_HEADER()
        {

            // messageCode = "2005";
            // messageDesc = "CONTAINER_HEADER";

        }
    }

    public class CONTAINER
    {
        // public string companyId;
        // public string sellerId;               // vendor/seller for 3PL
        // public string facilityId;
        public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode;
        public string messageDesc;
        public CONT_HEADER containerHeader;
        public LINE_DETAIL[] containerLineDetail;    //array
                                                     // public string message_ts;

        public CONTAINER(int numContainerLines)
        {
            containerLineDetail = new LINE_DETAIL[numContainerLines];
            //messageCode = "2004";
            //messageDesc = "CONTAINER";
        }
    }

    public class ORDER
    {
        public string companyId;
        public string sellerId;
        public string facilityId;
        public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode;
        public string messageDesc;
        public ORDER_HEADER orderHeader;
        public CONT_HEADER[] orderContainers;        //array
        public LINE_DETAIL[] orderLineDetail;        //array
        public string message_ts;

        public ORDER(int numOrderContainers, int numOrderLines)
        {
            companyId = "";
            sellerId = "";
            facilityId = "";
            messageNumber = "";
            messageCode = "2002";
            messageDesc = "ORDER";
            message_ts = "";
            orderHeader = new ORDER_HEADER();
            orderContainers = new CONT_HEADER[numOrderContainers];
            orderLineDetail = new LINE_DETAIL[numOrderLines];
        }
        public ORDER(int numOrderLines)
        {
            companyId = "";
            sellerId = "";
            facilityId = "";
            messageNumber = "";
            messageCode = "2002";
            messageDesc = "ORDER";
            message_ts = "";
            orderHeader = new ORDER_HEADER();
            orderLineDetail = new LINE_DETAIL[numOrderLines];
        }
    }

    public class WAVE
    {
        public string companyId;
        public string sellerId;
        public string facilityId;
        public string messageNumber;          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode;
        public string messageDesc;
        public WAVE_HEADER waveHeader;
        public ORDER[] waveDetail;             //array
        public string message_ts;

        public WAVE(int numOrders)
        {
            waveDetail = new ORDER[numOrders];
            messageCode = "2000";
            messageDesc = "WAVE";
        }

    }
    public class MsgResponse
    {
        public string status { get; set; }
        public string statusCode { get; set; }
        public string statusDesc { get; set; }
        public string messageNumber { get; set; }
        public string messageTimeStamp { get; set; }

    }


    //==============Cont Message===========

    public class CONT_HEADER2
    {
        public string batchId { get; set; }
        public string unitSortZone { get; set; }
        public string user { get; set; }
        public string containerBarCode { get; set; }
        public string detailCount { get; set; }
        public string wmsContainerType { get; set; }

    }

    public class CONTAINER2
    {
        public string companyId { get; set; }
        public string facilityId { get; set; }
        public string messageNumber { get; set; }          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string messageCode { get; set; }
        public string messageDesc { get; set; }
        public CONT_HEADER2 containerHeader { get; set; }
        public LINE_DETAIL_C[] containerLineDetail { get; set; }    //array
                                                                    // public string message_ts;
        public string message_ts { get; set; }

        public CONTAINER2(int numContainerLines)
        {
            containerLineDetail = new LINE_DETAIL_C[numContainerLines];
            messageCode = "2004";
            messageDesc = "CONTAINER";
        }
    }

    public class LINE_DETAIL_C
    {
        public string batchId { get; set; }
        public string containerBarCode { get; set; }
        public string lineItemId { get; set; }
        public string wmsLocationId { get; set; }
        public string wmsPickZone { get; set; }
        public string sku { get; set; }
        public string skuDesc { get; set; }
        public string requestedQty { get; set; }      // actually NUMERIC (ulong) but string for now (for ease of use)
        public string actualQty { get; set; }          // actually NUMERIC (ulong) but string for now (for ease of use)
        public string hazmat { get; set; }
        public string productCode { get; set; }
        public string user { get; set; }
    }

    //========================================BatchPut========================================================================

    public class BATCH_PUT
    {
        public string messageCode { get; set; }
        public string messageNumber { get; set; }
        public string sellerId { get; set; }
        public string companyId { get; set; }
        public string facilityId { get; set; }
        public string messageDesc { get; set; }
        public string batchId { get; set; }
        public string zone { get; set; }
        public List<string> orderIds { get; set; }
        public List<ORDER_CONTAINERS> orderContainers { get; set; }
        public string message_ts { get; set; }

    }

    public class ORDER_CONTAINERS
    {
        public string priority { get; set; }
        public string containerBarcode { get; set; }
        public string wmsContainerId { get; set; }
        public List<CONTAINER_DETAIL> containerDetail { get; set; }
    }

    public class CONTAINER_DETAIL
    {
        public string productCode { get; set; }
        public string sku { get; set; }
        public string requestedQty { get; set; }
    }


    //========================================================================================================================
}