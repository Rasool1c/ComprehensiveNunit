using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ComprehensiveNunit
{
    public class ReadFromExcel
    {

        public string ReadExcelName()
        {
            string path = @"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\Details.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0); //sheet number
            var row = sheet.GetRow(1); //row number
            string Fname = row.GetCell(0).StringCellValue.Trim(); //clm/cell number
            Console.WriteLine("the first name from excels is " +Fname);
            return Fname;

        }
        public string ReadExcelEmail()
        {
            string path = @"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\Details.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0); //sheet number
            var row = sheet.GetRow(1); //row number
            string Eaddress = row.GetCell(1).StringCellValue.Trim(); //clm/cell number
            Console.WriteLine("the first name from excels is " + Eaddress);
            return Eaddress;

        }
        public string ReadExcelPassword()
        {
            string path = @"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\Details.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0); //sheet number
            var row = sheet.GetRow(1); //row number
            string ExcelPass = row.GetCell(2).StringCellValue.Trim(); //clm/cell number
            Console.WriteLine("the first name from excels is " + ExcelPass);
            return ExcelPass;

        }
    }
}
