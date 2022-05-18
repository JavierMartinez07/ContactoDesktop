using ContactoDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace ContactoDesktop.Services
{
    public class ContactoServices
    {
        private static string host = "http://localhost:61103/Contacto/";

        public static List<Contacto> GetContactos()
        {
            try
            {
                var client = new WebClient();
                
                    client.Headers.Add("Content-Type:application/json"); //Content-Type 
                    client.Headers.Add("Accept:application/json");
                    string result = client.DownloadString(host + "GetContatos");
                    var resultObjects = JsonConvert.DeserializeObject<ResponseModel<Contacto>>(result);
                    return resultObjects.Records;
                
            }
            catch (Exception e)
            {

               MessageBox.Show(e.Message);
                return new List<Contacto>();

            }

        }

        public static ResponseModel<Contacto> DeleteContacto(int Id)
        {
            try
            {
                var client = new WebClient();

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString(host+"DeleteContactoById", "Delete", Id.ToString());
                var resultObjects = JsonConvert.DeserializeObject<ResponseModel<Contacto>>(result);
                return resultObjects;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                var error =  new ResponseModel<Contacto>();
                error.OK = false;
                return error;

            }

        }
        
        public static ResponseModel<Contacto> InsertContacto(Contacto model)
        {
            try
            {
                var client = new WebClient();

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                string RequestData = JsonConvert.SerializeObject(model);
                var result = client.UploadString(host+"InsertContacto", "Post", RequestData);
                var resultObjects = JsonConvert.DeserializeObject<ResponseModel<Contacto>>(result);
                return resultObjects;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                var error =  new ResponseModel<Contacto>();
                error.OK = false;
                return error;

            }

        }   
        
        public static bool VerifyEmailContacto(Contacto model)
        {
            try
            {
                var client = new WebClient();

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                string RequestData = JsonConvert.SerializeObject(model);
                var result = client.UploadString(host+"VerifyEmailContacto", "Post", RequestData);
                var resultObjects = JsonConvert.DeserializeObject<ResponseModel<Contacto>>(result);
                var cantidadEmail = resultObjects.Values[0];
                if (cantidadEmail == 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return false;

            }

        }

    }
}
