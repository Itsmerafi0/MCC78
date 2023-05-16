﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnection.Context
{
    public class MyConnection
    {
        private static readonly string connectionString =
    "Data Source=RAFI;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        public static SqlConnection Get()
        {

            return new SqlConnection(connectionString);
        }
    }
}