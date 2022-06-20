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

    public class DiaDiemService : BaseService
    { 
        [WebMethod]
        public JsonResponse<List<DiaDiem>> index()
        {
            return new JsonResponse<List<DiaDiem>>()
            {
                Error = false,
                Message = "Lấy dữ liệu thành công",
                Data = db.DiaDiems.ToList(),
                StatusCode = 200
            };
        }
        [WebMethod]
        public JsonResponse<string> store(int HinhAnhId, int DanhMucId, string DiaChi, string TenDiaDiem, int NguoiTao, string MoTaNgan, string MoTa, string NgayTao)
        {
            try
            { 
                DiaDiem dd = new DiaDiem();
                dd.HinhAnhId = HinhAnhId;
                dd.DanhMucId = DanhMucId;
                dd.DiaChi = DiaChi;
                dd.TenDiaDiem = TenDiaDiem;
                dd.NguoiTao = NguoiTao;
                dd.MoTaNgan = MoTaNgan;
                dd.MoTa = MoTa;
                if (!string.IsNullOrEmpty(NgayTao))
                    dd.NgayTao = DateTime.Parse(NgayTao);
                else
                    dd.NgayTao = DateTime.Now;
                
                db.DiaDiems.InsertOnSubmit(dd);
                db.SubmitChanges();
                return new JsonResponse<string>()
                {
                    Error = false,
                    Message = "Thêm địa điểm thành công",
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
        public JsonResponse<bool> update(int Id, int HinhAnhId, int DanhMucId, string DiaChi, string TenDiaDiem, int NguoiTao, string MoTaNgan, string MoTa, string NgayTao)
        {
            try
            {
                DiaDiem dd = db.DiaDiems.Single(d => d.Id == Id);
                dd.HinhAnhId = HinhAnhId;
                dd.DanhMucId = DanhMucId;
                dd.DiaChi = DiaChi;
                dd.TenDiaDiem = TenDiaDiem;
                dd.NguoiTao = NguoiTao;
                dd.MoTaNgan = MoTaNgan;
                dd.MoTa = MoTa;
                if (!string.IsNullOrEmpty(NgayTao))
                    dd.NgayTao = DateTime.Parse(NgayTao); 

                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Cập nhật địa điểm thành công",
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
                DiaDiem dd = db.DiaDiems.FirstOrDefault(d => d.Id == Id);
                db.DiaDiems.DeleteOnSubmit(dd);
                db.SubmitChanges();
                return new JsonResponse<bool>()
                {
                    Error = false,
                    Message = "Xoá địa điểm thành công",
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
