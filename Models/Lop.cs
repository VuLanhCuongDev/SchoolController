namespace SchoolController.Models
{
    public partial class Lop
    {
        public Lop()
        {
            DiemSos = new HashSet<DiemSo>();
        }

        public string MaLop { get; set; } = null!;
        public string TrangThai { get; set; } = null!;

        public virtual ICollection<DiemSo> DiemSos { get; set; }
    }
}
