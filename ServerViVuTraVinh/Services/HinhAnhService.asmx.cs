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
    public class HinhAnhService : System.Web.Services.WebService
    {
        private DBViVuTraVinhDataContext db = new DBViVuTraVinhDataContext();
        [WebMethod]
        public JsonResponse<List<HinhAnh>> index()
        {
            return new JsonResponse<List<HinhAnh>>()
            {
                Error = false,
                Message = "Lấy dữ liệu thành công",
                Data = db.HinhAnhs.ToList(),
                StatusCode = 200
            };
        }
        [WebMethod]
        public JsonResponse<string> store(string DuongDan, int NguoiTao)
        {
            try
            {
                db.HinhAnhs.InsertOnSubmit(
                    new HinhAnh() {
                        DuongDan = DuongDan,
                        NguoiTao = NguoiTao,
                        NgayTao = DateTime.Today
                    });
                db.SubmitChanges();
                return new JsonResponse<string>()
                {
                    Error = false,
                    Message = "Thêm hình ảnh thành công",
                    Data = "",
                    StatusCode = 200
                };
            } catch(Exception ex)
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
        public JsonResponse<bool> update(int Id, string DuongDan, int NguoiTao, string NgayTao = null)
        {
            try
            {
                HinhAnh ha = db.HinhAnhs.Single(h => h.Id == Id);
                ha.DuongDan = DuongDan;
                if (!string.IsNullOrEmpty(NgayTao))
                    ha.NgayTao = DateTime.Parse(NgayTao);
                ha.NguoiTao = NguoiTao;
                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Cập nhật hình ảnh thành công",
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
                HinhAnh ha = db.HinhAnhs.FirstOrDefault(h => h.Id == Id);
                db.HinhAnhs.DeleteOnSubmit(ha);
                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Xoá hình ảnh thành công",
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
