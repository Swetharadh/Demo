using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WakenBake.DAL;
using WakenBake.DAL.Repository;
using System.Web.Mvc;


namespace WakenBake.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbWakenBakeEntities context = new dbWakenBakeEntities();
        //private object db;

        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexViewModel CreateModel(string search)
       
        {
            SqlParameter[] param = new SqlParameter[] {
                   new SqlParameter("@search",search??(object)DBNull.Value)
                   };
            List<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList();
            return new HomeIndexViewModel
            {
                ListOfProducts = (IPagedList<Tbl_Product>)data
            };
        }
    }
}

