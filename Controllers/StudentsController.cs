using ApiDotnet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        [Route("GetStudent")]
        public IActionResult Get()
        {

            List<Student> list_student = new List<Student>() { };

            Student student = new Student();

            try
            {

                list_student.Add(new Student()
                {
                    nisn = "198209809128098",
                    nik = "09091089098120980",
                    alamat = "lorem",
                    created_at = DateTime.Now,
                    created_by = "admin",
                    jenis_kelamin = "L",
                    nama_siswa = "udin",
                    no_hp = "08517891379",
                    tempat_lahir = "depok",
                    tanggal_lahir = Convert.ToDateTime("2005-01-19 10:00:00"),
                });

                list_student.Add(new Student()
                {
                    nisn = "198209809128098",
                    nik = "09091089098120980",
                    alamat = "lorem",
                    created_at = DateTime.Now,
                    created_by = "admin",
                    jenis_kelamin = "L",
                    nama_siswa = "udin",
                    no_hp = "08517891379",
                    tempat_lahir = "depok",
                    tanggal_lahir = Convert.ToDateTime("2005-01-19 10:00:00"),
                });

                list_student.Add(new Student()
                {
                    nisn = "198209809128098",
                    nik = "09091089098120980",
                    alamat = "lorem",
                    created_at = DateTime.Now,
                    created_by = "admin",
                    jenis_kelamin = "L",
                    nama_siswa = "udin",
                    no_hp = "08517891379",
                    tempat_lahir = "depok",
                    tanggal_lahir = Convert.ToDateTime("2005-01-19 10:00:00"),
                });

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(new { student, list_student });
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Student model)
        {

            int status_code = 100;
            string massage = "";

            try
            {
                if (model != null)
                {
                    if (string.IsNullOrEmpty(model.nisn))
                    {
                        massage = "Nisn tidak boleh kosong!";
                    }
                    else if (string.IsNullOrEmpty(model.nik))
                    {
                        massage = "Nik tidak boleh kosong!";
                    }
                    else if (string.IsNullOrEmpty(model.nama_siswa))
                    {
                        massage = "Nama tidak boleh kosong!";
                    }
                    else if (model.jenis_kelamin != "P" || model.jenis_kelamin != "L")
                    {
                        massage = "Jenis Kelamin Hanya L / P !";
                    }
                    else if (string.IsNullOrEmpty(model.alamat))
                    {
                        massage = "Alamat tidak boleh kosong!";
                    }
                    else
                    {
                        status_code = 200;
                        massage = "Siswa Berhasil Disimpan!";
                    }

                }
                else
                {
                    massage = "parameter tidak boleh kosong!";
                }
            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(new { status_code, massage });
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string nisn)
        {
            var status_code = 100;
            var message = "";
            var list_student = new List<Student>() { };
            try
            {

                list_student.Add(new Student()
                {
                    nisn = "nisns001",
                    nik = "nik001",
                    nama_siswa = "Test Demo",
                    tempat_lahir = "Bogor",
                    tanggal_lahir = Convert.ToDateTime("2005-01-01 13:00:00"),
                    jenis_kelamin = "L",
                    no_hp = "123456789",
                    alamat = "Bogor",
                    created_at = DateTime.Now,
                    created_by = "SYSTEM",
                });

                list_student.Add(new Student()
                {
                    nisn = "nisns002",
                    nik = "nik002",
                    nama_siswa = "Test Demo2",
                    tempat_lahir = "Bogor",
                    tanggal_lahir = Convert.ToDateTime("2005-01-01 13:00:00"),
                    jenis_kelamin = "L",
                    no_hp = "556577",
                    alamat = "Bogor",
                    created_at = DateTime.Now,
                    created_by = "SYSTEM",
                });

                list_student.Add(new Student()
                {
                    nisn = "nisns003",
                    nik = "nik003",
                    nama_siswa = "Test Demo3",
                    tempat_lahir = "Bogor",
                    tanggal_lahir = Convert.ToDateTime("2005-01-01 13:00:00"),
                    jenis_kelamin = "L",
                    no_hp = "12113",
                    alamat = "Bogor",
                    created_at = DateTime.Now,
                    created_by = "SYSTEM",
                });

                var dataFind = list_student.Where(x => x.nisn == nisn).SingleOrDefault();
                if (dataFind != null)
                {
                    var delete = list_student.Remove(dataFind);
                    if (delete)
                    {
                        status_code = 200;
                        message = "Delete data success";
                    }
                    else
                    {
                        message = "Delete data failed";
                    }
                }
                else
                {
                    message = "Data not found";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Ok(new { status_code, message, list_student });
        }
    }


}
