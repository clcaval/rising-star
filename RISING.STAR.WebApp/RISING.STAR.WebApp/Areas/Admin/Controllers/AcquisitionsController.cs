using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RISING.STAR.DAL;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Areas.Admin.Controllers
{

    [RBAC]
    public class AcquisitionsController : Controller
    {
        private RISINGSTAREntities db = new RISINGSTAREntities();

        // GET: Admin/Acquisitions
        public async Task<ActionResult> Index()
        {
            var acquisitions_Table = db.Acquisitions_Table.Include(a => a.ExamType).Include(a => a.Patients_Table);
            return View(await acquisitions_Table.ToListAsync());
        }

        // GET: Admin/Acquisitions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquisitions_Table acquisitions_Table = await db.Acquisitions_Table.FindAsync(id);
            if (acquisitions_Table == null)
            {
                return HttpNotFound();
            }
            return View(acquisitions_Table);
        }

        // GET: Admin/Acquisitions/Create
        public ActionResult Create()
        {
            ViewBag.Type_Num = new SelectList(db.ExamTypes, "ExamTypeId", "ExamTypeName");
            ViewBag.FK_Guid_Patient = new SelectList(db.Patients_Table, "Guid", "NAME");
            return View();
        }

        // POST: Admin/Acquisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Acq,Guid,FK_Id_Patient,FK_Guid_Patient,DATE,HOUR,OS,OD,OS_OD,SPH,CYL,AXIS,BCVA,UCVA,REFERENCE_SPH_REFRAC,AP,NP,NOTES,BESTFOCUS,WIDTH_PROFILE_1_2,WIDTH_PROFILE_1_10,MTF_CUT_OFF,STREHL_RATIO,VA_100,VA_20,VA_9,OQAS_VALUE_100,OQAS_VALUE_20,OQAS_VALUE_9,Type_Num,Type,Corr_Type_Num,Corr_Type,NImag,NImag_Acc_Each,COMPUTED_IMAGES,OAR,OSI,Refrac_Acc_Per_1,Refrac_Acc_Per_2,AR,Time_Each_Image_TearFilm,TearFilm_Time,TearFilm_OSI,TearFilm_Central_Energy,TearFilm_Peripheral_Energy,TearFilm_VA,TearFilm_MTFCutoff,TearFilm_MeanOSI,TearFilm_StdevOSI,RotatedCamera,PKJ_IsPreOperation,PKJ_MicrasPerPixel,PKJ_PupilDiameter,PKJ_PkjVsPupil_Length,PKJ_PkjVsPupil_Angle,PKJ_PkjVsPupil_X,PKJ_PkjVsPupil_Y,PKJ_InlayVsPupil_X,PKJ_InlayVsPupil_Y,PKJ_InlayVsPkj_X,PKJ_InlayVsPkj_Y,PKJ_Pupil_PixelCentroX,PKJ_Pupil_PixelCentroY,PKJ_Pupil_PixelRadio,PKJ_Laser_PixelCentroX,PKJ_Laser_PixelCentroY,PKJ_Inlay_PixelCentroX,PKJ_Inlay_PixelCentroY,PKJ_Inlay_PixelRadio")] Acquisitions_Table acquisitions_Table)
        {
            if (ModelState.IsValid)
            {
                acquisitions_Table.Guid = Guid.NewGuid();
                db.Acquisitions_Table.Add(acquisitions_Table);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Num = new SelectList(db.ExamTypes, "ExamTypeId", "ExamTypeName", acquisitions_Table.Type_Num);
            ViewBag.FK_Guid_Patient = new SelectList(db.Patients_Table, "Guid", "NAME", acquisitions_Table.FK_Guid_Patient);
            return View(acquisitions_Table);
        }

        // GET: Admin/Acquisitions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquisitions_Table acquisitions_Table = await db.Acquisitions_Table.FindAsync(id);
            if (acquisitions_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Num = new SelectList(db.ExamTypes, "ExamTypeId", "ExamTypeName", acquisitions_Table.Type_Num);
            ViewBag.FK_Guid_Patient = new SelectList(db.Patients_Table, "Guid", "NAME", acquisitions_Table.FK_Guid_Patient);
            return View(acquisitions_Table);
        }

        // POST: Admin/Acquisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Acq,Guid,FK_Id_Patient,FK_Guid_Patient,DATE,HOUR,OS,OD,OS_OD,SPH,CYL,AXIS,BCVA,UCVA,REFERENCE_SPH_REFRAC,AP,NP,NOTES,BESTFOCUS,WIDTH_PROFILE_1_2,WIDTH_PROFILE_1_10,MTF_CUT_OFF,STREHL_RATIO,VA_100,VA_20,VA_9,OQAS_VALUE_100,OQAS_VALUE_20,OQAS_VALUE_9,Type_Num,Type,Corr_Type_Num,Corr_Type,NImag,NImag_Acc_Each,COMPUTED_IMAGES,OAR,OSI,Refrac_Acc_Per_1,Refrac_Acc_Per_2,AR,Time_Each_Image_TearFilm,TearFilm_Time,TearFilm_OSI,TearFilm_Central_Energy,TearFilm_Peripheral_Energy,TearFilm_VA,TearFilm_MTFCutoff,TearFilm_MeanOSI,TearFilm_StdevOSI,RotatedCamera,PKJ_IsPreOperation,PKJ_MicrasPerPixel,PKJ_PupilDiameter,PKJ_PkjVsPupil_Length,PKJ_PkjVsPupil_Angle,PKJ_PkjVsPupil_X,PKJ_PkjVsPupil_Y,PKJ_InlayVsPupil_X,PKJ_InlayVsPupil_Y,PKJ_InlayVsPkj_X,PKJ_InlayVsPkj_Y,PKJ_Pupil_PixelCentroX,PKJ_Pupil_PixelCentroY,PKJ_Pupil_PixelRadio,PKJ_Laser_PixelCentroX,PKJ_Laser_PixelCentroY,PKJ_Inlay_PixelCentroX,PKJ_Inlay_PixelCentroY,PKJ_Inlay_PixelRadio")] Acquisitions_Table acquisitions_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acquisitions_Table).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Num = new SelectList(db.ExamTypes, "ExamTypeId", "ExamTypeName", acquisitions_Table.Type_Num);
            ViewBag.FK_Guid_Patient = new SelectList(db.Patients_Table, "Guid", "NAME", acquisitions_Table.FK_Guid_Patient);
            return View(acquisitions_Table);
        }

        // GET: Admin/Acquisitions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquisitions_Table acquisitions_Table = await db.Acquisitions_Table.FindAsync(id);
            if (acquisitions_Table == null)
            {
                return HttpNotFound();
            }
            return View(acquisitions_Table);
        }

        // POST: Admin/Acquisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Acquisitions_Table acquisitions_Table = await db.Acquisitions_Table.FindAsync(id);
            db.Acquisitions_Table.Remove(acquisitions_Table);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
