using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Patriot.Database;
using Patriot.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patriot.Helper
{
    public class ImportService
    {
        private DataContext _DataContext;
        private IMapper _mapper;


        public ImportService(DataContext dataContext, IMapper mapper)
        {
            _DataContext = dataContext;
            _mapper = mapper;
        }
        public bool ImportExcelData(IFormFile file)
        {
            try
            {
                if (!file.FileName.Contains(".xlsx") || !file.FileName.Contains(".xls"))
                    throw new Exception("File Format must be (xlsx or xls)");

                var MasterLetters = new List<MasterLetter>();
                using (var stream = new System.IO.MemoryStream())
                {
                    file.CopyTo(stream);
                    using (ExcelPackage package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (workSheet == null)
                            throw new Exception("File Format must be correct");
                        int totalRows = workSheet.Dimension.Rows;

                        for (int i = 2; i <= totalRows; i++)
                        {
                            var masterLetter = new MasterLetter();

                            masterLetter.Client = Convert.ToString(workSheet.Cells[i, 1].Value);
                            masterLetter.Entity = Convert.ToString(workSheet.Cells[i, 2].Value);
                            masterLetter.LetterType = Convert.ToString(workSheet.Cells[i, 3].Value);
                            masterLetter.VisitNo = Convert.ToString(workSheet.Cells[i, 4].Value);
                            masterLetter.InsuranceName = Convert.ToString(workSheet.Cells[i, 5].Value);
                            masterLetter.InsuranceID = Convert.ToString(workSheet.Cells[i, 6].Value);
                            masterLetter.LastName = Convert.ToString(workSheet.Cells[i, 7].Value);
                            masterLetter.FirstName = Convert.ToString(workSheet.Cells[i, 8].Value);
                            masterLetter.DOS = DateTime.Parse(Convert.ToString(workSheet.Cells[i, 9].Value));
                            masterLetter.CheckAmount = Convert.ToDecimal(workSheet.Cells[i, 10].Value);
                            masterLetter.Address1 = Convert.ToString(workSheet.Cells[i, 11].Value);
                            masterLetter.Address2 = Convert.ToString(workSheet.Cells[i, 12].Value);
                            masterLetter.City = Convert.ToString(workSheet.Cells[i, 13].Value);
                            masterLetter.State = Convert.ToString(workSheet.Cells[i, 14].Value);
                            masterLetter.Zipcode = Convert.ToString(workSheet.Cells[i, 15].Value);
                            masterLetter.ImportDate = DateTime.Now;
                            masterLetter.LetterGeneratedIndex = 0;

                            MasterLetters.Add(masterLetter);
                        }
                    }
                }

                //add new records
                _DataContext.MasterLetters.AddRange(MasterLetters);
                _DataContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
