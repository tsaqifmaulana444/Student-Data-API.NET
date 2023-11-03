namespace ApiDotnet.Models
{
    public class Student
    {

        public Student()
        {

        }

        public Student(
            string nisn,
            string nik,
            string nama_siswa,
            string tempat_lahir,
            DateTime tanggal_lahir,
            string jenis_kelamin,
            string no_hp,
            string telegram_id,
            string alamat,
            DateTime created_at,
            string created_by,
            DateTime updated_at,
            string updated_by
            )
        {

        }

        public string nisn { get; set; } // primary
        public string nik { get; set; } // unique
        public string nama_siswa { get; set; }
        public string tempat_lahir { get; set; }
        public DateTime tanggal_lahir { get; set; }
        public string jenis_kelamin { get; set; }
        public string no_hp { get; set; }
        public string telegram_id { get; set; }
        public string alamat { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        public DateTime updated_at { get; set; }
        public string updated_by { get; set; }

    }
}
