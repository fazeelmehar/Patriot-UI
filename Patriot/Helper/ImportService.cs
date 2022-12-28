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

                var CPTLetters = new List<CPTLetter>();
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
                            var cptLetter = new CPTLetter();

                            cptLetter.Client = Convert.ToString(workSheet.Cells[i, 1].Value);
                            cptLetter.VisitNo = Convert.ToString(workSheet.Cells[i, 2].Value);
                            cptLetter.PatientLastName = Convert.ToString(workSheet.Cells[i, 3].Value);
                            cptLetter.PatientFirstName = Convert.ToString(workSheet.Cells[i, 4].Value);
                            cptLetter.DOS = DateTime.Parse(Convert.ToString(workSheet.Cells[i, 5].Value));
                            cptLetter.CheckAmount = Convert.ToDecimal(workSheet.Cells[i, 6].Value);
                            cptLetter.DatesOfCPTLetter = Convert.ToString(workSheet.Cells[i, 7].Value);
                            cptLetter.Comments = Convert.ToString(workSheet.Cells[i, 8].Value);
                            cptLetter.Status = Convert.ToString(workSheet.Cells[i, 9].Value);
                            cptLetter.DateLetterWasMailed = Convert.ToString(workSheet.Cells[i, 10].Value);
                            cptLetter.Address1 = Convert.ToString(workSheet.Cells[i, 11].Value);
                            cptLetter.Address2 = Convert.ToString(workSheet.Cells[i, 12].Value);
                            cptLetter.City = Convert.ToString(workSheet.Cells[i, 13].Value);
                            cptLetter.State = Convert.ToString(workSheet.Cells[i, 14].Value);
                            cptLetter.Zipcode = Convert.ToString(workSheet.Cells[i, 15].Value);
                            cptLetter.Created = DateTime.Now;

                            CPTLetters.Add(cptLetter);
                        }
                    }
                }

                //add new records
                _DataContext.CPTLetters.AddRange(CPTLetters);
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
