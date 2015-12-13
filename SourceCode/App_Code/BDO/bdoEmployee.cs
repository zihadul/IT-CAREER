using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class bdoEmployee
{
    private string _strCode;
    private string _strName;
    private int _intAge;
    private string _strDepartment;

    public bdoEmployee(string strCode, string strName, int intAge, string strDepartment)
    {
        _strCode = strCode;
        _strName = strName;
        _intAge = intAge;
        _strDepartment = strDepartment;
    }

    public string Code
    {
        get
        {
            return _strCode;
        }       
    }

    public string Name
    {
        get
        {
            return _strName;
        }        
    }
    public int Age
    {
        get
        {
            return _intAge;
        }
    }

    public string Department
    {
        get
        {
            return _strDepartment;
        }
    }
}