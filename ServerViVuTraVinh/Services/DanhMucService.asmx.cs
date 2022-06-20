using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServerViVuTraVinh.Helpers;

namespace ServerViVuTraVinh.Services
{ 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    public class DanhMucServie : System.Web.Services.WebService
    {

        private DBViVuTraVinhDataContext db = new DBViVuTraVinhDataContext();
        [WebMethod]
        public JsonResponse<List<DanhMuc>> index()
        {
            return new JsonResponse<List<DanhMuc>>()
            {
                Error = false,
                Message = "Lấy dữ liệu thành công",
                Data = db.DanhMucs.ToList(),
                StatusCode = 200
            };
        }
        [WebMethod]
        public JsonResponse<string> store(string TenDanhMuc, string MoTa, string NgayTao = null, string TrangThai = "1")
        {
            try
            {
                db.DanhMucs.InsertOnSubmit(
                    new DanhMuc()
                    {
                        TenDanhMuc = TenDanhMuc,
                        MoTa = MoTa,
                        NgayTao = !string.IsNullOrEmpty(NgayTao) ? DateTime.Parse(NgayTao) : DateTime.Today,
                        TrangThai = Int32.Parse(TrangThai)
                    });
                db.SubmitChanges();
                return new JsonResponse<string>()
                {
                    Error = false,
                    Message = "Thêm danh mục thành công",
                    Data = "",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<string>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = "",
                    StatusCode = 200
                };
            }
        }
        [WebMethod]
        public JsonResponse<bool> update(int Id, string TenDanhMuc, string MoTa, string NgayTao = null, string TrangThai = "1")
        {
            try
            {
                DanhMuc dm = db.DanhMucs.Single(d => d.Id == Id);
                dm.TenDanhMuc = TenDanhMuc;
                dm.MoTa = MoTa;
                if(!string.IsNullOrEmpty(NgayTao))
                    dm.NgayTao = DateTime.Parse(NgayTao);
                dm.TrangThai = Int32.Parse(TrangThai);

                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Cập nhật danh mục thành công",
                    Data = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<bool>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = false,
                    StatusCode = 200
                };
            }
        }
        [WebMethod]
        public JsonResponse<bool> delete(int Id)
        {
            try
            {
                DanhMuc dm = db.DanhMucs.FirstOrDefault(d => d.Id == Id);
                db.DanhMucs.DeleteOnSubmit(dm);
                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Xoá danh mục thành công",
                    Data = true,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResponse<bool>()
                {
                    Error = true,
                    Message = ex.Message,
                    Data = false,
                    StatusCode = 200
                };
            }
        }
    }
}
