using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortageApp.Web.Models;
using Mortgage.Services.Interfaces;

namespace MortageApp.Web.Controllers
{
    public class MortgageController : Controller
    {
        private readonly IMortgageDetails _mortgageDetails;
        public MortgageController(IMortgageDetails mortgageDetails)
        {
            _mortgageDetails = mortgageDetails;
        }
        // GET: MortgageController
        public ActionResult Index(string searchString, string sorting)
        {
            List<MortgageViewModel> listMortgage = new List<MortgageViewModel>();
            var mortgageList = _mortgageDetails.GetAllMortages().ToList();

            //--------Searching by name and sorting---------
            //Search has been done for name and terms only. Other is pending
            if (!string.IsNullOrWhiteSpace(searchString))
                mortgageList = _mortgageDetails.GetAllMortages().Where(x => x.Name.Contains(searchString)
                || x.TermsInMonths.ToString() == searchString).ToList();

            if (!string.IsNullOrWhiteSpace(sorting))
                mortgageList = _mortgageDetails.ApplySorting(mortgageList, sorting);
            //-----------end searching and sorting-----------
            foreach (var item in mortgageList)
            {
                listMortgage.Add(new MortgageViewModel()
                {
                    MortgageId = item.MortgageId,
                    Name = item.Name,
                    MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), item.MortgageType.ToString()),
                    InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), item.InterestRepayment.ToString()),
                    EffectiveStartDate = item.EffectiveStartDate,
                    EffectiveEndDate = item.EffectiveEndDate,
                    TermsInMonths = item.TermsInMonths,
                    CancellationFee = item.CancellationFee,
                    EstablishmentFee = item.EstablishmentFee,
                    SchemaIdentifier = item.SchemaIdentifier
                });
            }
            return View(listMortgage);
        }

        // GET: MortgageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MortgageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MortgageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MortgageViewModel collection)
        {
            try
            {
                Mortgage.Data.Entity.Mortgage mortgage = new Mortgage.Data.Entity.Mortgage();
                mortgage.Name = collection.Name;
                //mortgage.MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), collection.MortgageType.ToString());
                //mortgage.InterestRepayment = collection.InterestRepayment;
                mortgage.EffectiveStartDate = collection.EffectiveStartDate;
                mortgage.EffectiveEndDate = collection.EffectiveEndDate;
                mortgage.TermsInMonths = collection.TermsInMonths;
                mortgage.CancellationFee = collection.CancellationFee;
                mortgage.EstablishmentFee = collection.EstablishmentFee;
                _mortgageDetails.AddMortgage(mortgage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MortgageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MortgageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MortgageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MortgageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string input)
        {
            return View();
        }
    }
}
