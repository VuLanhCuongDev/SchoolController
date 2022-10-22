namespace SchoolController.Models
{
    public partial class ChuyenNganh
    {
        public ChuyenNganh()
        {
            MaMonHocs = new HashSet<MonHoc>();
        }

        public string MaChuyenNganh { get; set; } = null!;
        public string TenChuyenNganh { get; set; } = null!;

        public virtual ICollection<MonHoc> MaMonHocs { get; set; }
    }
}
