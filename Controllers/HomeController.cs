using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Linq_practice_studnet_6.Models;
using Linq_practice_studnet_6.DataAccess;
namespace Linq_practice_studnet_6
{
    public class HomeController : Controller
    {
       public static ResearchSitesDbContext dbContext;
        public HomeController(ResearchSitesDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
          //  populateData();
             //populateResearchData ();
            return View();
        }

        //public async Task<IActionResult> getAuthors()
        //{
            // var userlist = dbContext.Users.Include(u => u.documents).Where(u=>u.documents.Count!=0).ToList();
            // var doclist = dbContext.Documents.Include(x => x.User).Where(x => x.Title.Equals("ABC")).ToList();
            //var downloadlist= dbContext.Downloads.Include(y => y.Document).Where(y => y.Downloaded_date == DateTime.Now && y.User!=null&&y.User.Id == 1);
          //  var researchlist= dbContext.Documents.GroupBy(x => new { x.AreaofResearch }).Select(x => new { totalcount = x.Count(), researcharea = x.Key.AreaofResearch }).OrderByDescending(x => x.totalcount).ToList().Take(2);
          //  var downloadlist = dbContext.Downloads.Include(s => s.Document).GroupBy(x => new { docId = x.Document.Id, docname = x.Document.Title }).Select(x => new { totalcount = x.Count(), title = x.Key.docname }).OrderByDescending(x => x.totalcount).ToList().Take(2);
        //    ViewData["title"] = "authors";
        //    ViewData["data"] = doclist;
        //    return View(doclist);
        //}

        public ViewResult getAuthors()
        {
            var userlist = dbContext.Users.Include(u => u.documents).Where(u=>u.documents.Count!=0).ToList();
            ViewData["title"] = "authors";
            ViewData["data"] = userlist;
            return View("authors");
        }

        public ViewResult getDownloads(int userId,string date)
        {
            DateTime d = Convert.ToDateTime(date);
            var downloadlist= dbContext.Downloads.Include(y => y.Document).Include(y=>y.User).Where(y => y.Downloaded_date.Date == d.Date && y.User!=null&&y.User.Id == userId);
            ViewData["title"] = "downloads";
            ViewData["data"] = downloadlist;
            return View("downloads");
        }

        public ViewResult getSpecificAuthors(string researchArea)
        {
            var doclist = dbContext.Documents.Include(x => x.User).Where(x => x.AreaofResearch.Equals(researchArea)).ToList();
            ViewData["title"] = "specificAuthors";
            ViewData["data"] = doclist;
            return View("specificAuthors");
        }

        public ViewResult getTopResearchDetails()
        {
            var researchlist = dbContext.Documents.GroupBy(x => new { x.AreaofResearch }).Select(x => new { totalcount = x.Count(), researcharea = x.Key.AreaofResearch }).OrderByDescending(x => x.totalcount).ToList().Take(2);
            ViewData["title"] = "researchList";
            ViewData["data"] = researchlist;
            return View("researchList");
        }

        public ViewResult getTopDownloads()
        {
            var downloadlist = dbContext.Downloads.Include(s => s.Document).Where(s=>s.Document!=null).GroupBy(x => new { docId = x.Document.Id, docname = x.Document.Title }).Select(x => new { totalcount = x.Count(), title = x.Key.docname }).OrderByDescending(x => x.totalcount).ToList().Take(2);
            ViewData["data"] = downloadlist;
            return View("downloadlist");
        }
        //p
        //ublic async Task<IActionResult> getspecificAuthors()
        //{
        //    var usersList = dbContext.Users.Include(u => u.documents).Where(u =>u.)

        //    ViewData["title"] = "authors";
        //    ViewData["data"] = usersList;
        //    return View(usersList);
        //}
        //public async Task<IActionResult> Queries()
        //{

        //    List<Enrollment> l = dbContext.Enrollments.Include(e => e.Course).Where(e => e.Course.Number.Equals("ISM 6225")).ToList();
        //    var group_data = (dbContext.Enrollments.Include(e => e.Student).Include(e => e.Course)
        //        .Include(e => e.Course.College).GroupBy(e => new { e.Course.College.Name })).Select(s => new { College = s.Key.Name, Enrollments = s.ToList() }).ToList();
        //    ViewData["title"] = "allrecords";
        //    ViewData["data"] = group_data;
        //    return View("allrecords");


        //}


        //void populateData()
        //{
        //    Random rnd = new Random();

        //    string[] Colleges = {
        //                         "Muma College of Business, MCOB",
        //                         "College of Engineering, CoE",
        //                         "College of Arts and Sciences, CAS",
        //                         "College of Nursing, CON",
        //                         "Morsani College of Medicine,MCOM",
        //                         "College of Public Health,COPH"
        //    };
        //    string[] Courses = {
        //        "ISM 6225, Distributed Information Systems",
        //        "ISM 6218, Advanced Database Management Systems",
        //        "ISM 6137, Statistical Data Mining",
        //        "ISM 6419, Data Visualization",
        //        "ISM 6930, Blockchain Fundamentals",
        //        "ISM 6562, Big Data for Business",
        //        "ISM 6328, Information Security and IT Risk Management",
        //        "QMB 6304, Analytical Methods For Business",
        //        "ISM 6136, Data Mining",
        //        "NUR 3125, Pathophysiology for Nursing Practice",
        //        "NUR 3145, Pharmacology in Nursing Practice",
        //        "NUR 4165, Nursing Inquiry",
        //        "NUR 3078, Information Technology Skills for Nurses",
        //        "NUR 4169, Evidence-Based Practice for Baccalaureate Prepared Nurse",
        //        "NUR 4634, Population Health",
        //        "NSP 3147, Web-Based Education for Staff Development"

        //    };

        //    string[] Students = {
        //        "Monica", "Sara","Adam","Jude","Callie","Ross","Stark",
        //        "Chandler","Phoebe","Carrie","Tristan","sally","Robert",
        //        "Sid","Warner","Joey","Andy","Conner","Ruby","Kate"
        //    };
        //    string[] Grades = { "A", "A-", "B+", "B", "B-" };
        //    int[] scores = { 95, 91, 87, 82, 75,66,55,80,63,90,45,60};

        //    College[] colleges = new College[Colleges.Length];
        //    Course[] courses = new Course[Courses.Length];
        //    Student[] students = new Student[Students.Length];

        //    for (int i = 0; i < Colleges.Length; i++)
        //    {
        //        College college = new College
        //        {
        //            Name = Colleges[i].Split(",")[0],
        //            Abbreviation = Colleges[i].Split(",")[1]
        //        };

        //        dbContext.Colleges.Add(college);
        //        colleges[i] = college;
        //    }

        //    for (int i = 0; i < Courses.Length; i++)
        //    {
        //        Course course = new Course
        //        {

        //            Number = Courses[i].Split(",")[0],
        //            Name = Courses[i].Split(",")[1],
        //            College = colleges[rnd.Next(colleges.Length)]
        //        };

        //        dbContext.Courses.Add(course);
        //        courses[i] = course;
        //    }

        //    for (int i = 0; i < Students.Length; i++)
        //    {
        //        Student student = new Student
        //        { 
        //            Name = Students[i] 
        //        };

        //        dbContext.Students.Add(student);
        //        students[i] = student;
        //    }

        //    foreach (Student student in students)
        //    {
        //        foreach (Course course in courses)
        //        {
        //            Enrollment enrollment = new Enrollment
        //            {
        //                Course = course,
        //                Student = student,
        //                Grade = Grades[rnd.Next(Grades.Length)],
        //                score=scores[rnd.Next(scores.Length)]
        //            };

        //            dbContext.Enrollments.Add(enrollment);
        //        }
        //    }

        //    dbContext.SaveChanges();
        //}

        public static void populateResearchData()
        {
            string[] users = {
                "Monica Charles", "Sara Jines","Adam Spykar","Jude Charles","Callie Charles","Ross Charles","Stark Charles",
                "Chandler Jines","Phoebe Jines","Carrie Jines","Tristan Jines","sally Jines","Robert Jines",
                "Sid Jines","Warner Spykar","Joey Spykar","Andy Spykar","Conner Spykar","Ruby Spykar","William smith"
            };
            string[] ResearchTopics = {
                "ISM 6225, Distributed Information Systems",
                "ISM 6218, Advanced Database Management Systems",
                "ISM 6137, Statistical Data Mining",
                "ISM 6419, Data Visualization",
                "ISM 6930, Blockchain Fundamentals",
                "ISM 6562, Big Data for Business",
                "ISM 6328, Information Security and IT Risk Management",
                "QMB 6304, Analytical Methods For Business",
                "ISM 6136, Data Mining",
                "NUR 3125, Pathophysiology for Nursing Practice",
                "NUR 3145, Pharmacology in Nursing Practice",
                "NUR 4165, Nursing Inquiry",
                "NUR 3078, Information Technology Skills for Nurses",
                "NUR 4169, Evidence-Based Practice for Baccalaureate Prepared Nurse",
                "NUR 4634, Population Health",
                "NSP 3147, Web-Based Education for Staff Development"

            };
            //int userno = 0;
            //int i = 0;
            List<Document> dl = new List<Document>();
            List<Download> ddthree = new List<Download>();
            List<Download> ddtwo = new List<Download>();
            dbContext.Downloads.Add(new Download() { Downloaded_date = DateTime.Today });
            dbContext.Downloads.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(2) });
            dbContext.Downloads.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(4) });
            ddthree.Add(new Download() { Downloaded_date = DateTime.Today });
            ddthree.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(8) });
            ddthree.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(15) });

            ddtwo.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(20) });
            ddtwo.Add(new Download() { Downloaded_date = DateTime.Today.AddDays(21) });
            bool swap = false;
            foreach (string s in ResearchTopics)
            {

                if (s.Length % 2 == 0)
                {
                    if (swap == false)
                    {
                        Document doc = new Document() { Title = "GHI", AreaofResearch = s, Downloads = ddthree };
                        dl.Add(doc);
                        dbContext.Documents.Add(doc);
                        swap = true;
                    }
                    else
                    {
                        Document doc = new Document() { Title = "GHI", AreaofResearch = s, Downloads = ddtwo };
                        dl.Add(doc);
                        dbContext.Documents.Add(doc);
                        swap = false;
                    }
                }
                else
                {
                    if (swap == false)
                    {
                        Document doc = new Document() { Title = "KLM", AreaofResearch = s, Downloads = ddthree };
                        dl.Add(doc);
                        dbContext.Documents.Add(doc);
                        swap = true;
                    }
                    else
                    {
                        Document doc = new Document() { Title = "KLM", AreaofResearch = s, Downloads = ddtwo };
                        dl.Add(doc);
                        dbContext.Documents.Add(doc);
                        swap = false;
                    }

                }

            }
            int i = 0;
            
            foreach (string s in users)
            {   string[] names = s.Split(' ');
                User u;
                if (swap == false)
                {
                     u = new User() { Firstname = names[0], Lastname = names[1], documents = dl, downloads = ddthree };
                    swap = true;
                }
                else
                {
                    u = new User() { Firstname = names[0], Lastname = names[1], documents = dl, downloads = ddtwo };
                    swap = false;
                }
                dbContext.Users.Add(u);
            }
            //   userno = i;
            //  int docno = 0;
            //   i = 0;

            //   int p = 0;
            //for(int k = 0; k < userno; k++)
            //   {

            //       for(int j = 0; j < docno; j++)
            //       {
            //           Download down = new Download() { Downloaded_date = DateTime.Now };
            //           dbContext.Downloads.Add(down);
            //       }
            //   }
            //List<Document> documentslist = dbContext.Documents.Take(5).ToList<Document>();
            //dbContext.Users.Take(5).Select(s=>s.documents=documentslist);
            //new { College = s.Key.Name, Enrollments = s.ToList() }
            //dbContext.Users.
            dbContext.SaveChanges();
        }
    }
}
