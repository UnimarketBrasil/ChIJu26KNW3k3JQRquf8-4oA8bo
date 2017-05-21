using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilitario
{
    public class GeoCodificacao
    {
        //MÉTODO RECEBE UM OBJETO USUAARIO, CEP E NÚMERO
        //OBTEM LATITUDE E LOGITUDE
        //RETORNA UM UM OBJETO USUÁRIO COM LATITUDE E LONGITUDE
        public Usuario ObterCoordenadas(Usuario user, string cep, string numero)
        {
            DataSet data = new DataSet();

            try
            {
                string viacep = string.Format("https://viacep.com.br/ws/{0}/xml/", cep);
                data.ReadXml(viacep);
                string enderecoPorCep = data.Tables[0].Rows[0]["logradouro"].ToString().Trim() + ", " + data.Tables[0].Rows[0]["bairro"].ToString().Trim() + ", " + data.Tables[0].Rows[0]["localidade"].ToString().Trim();

                string googleMaps = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y&new_forward_geocoder=true&address={0},{1}", enderecoPorCep, numero);
                data = new DataSet();
                data.ReadXml(googleMaps);
                if (data != null && data.Tables["address_component"].Rows.Count >= 7)
                {
                    user.Latitude = data.Tables["location"].Rows[0]["lat"].ToString();
                    user.Longitude = data.Tables["location"].Rows[0]["lng"].ToString();
                    data.Dispose();
                    return user;
                }
                else
                {
                    return user = null;
                }
            }
            catch (Exception)
            {
                return user = null;
            }

        }

        //MÉTODO RECEBE UM OBJETO USUARIO COM LATITUDE E LONGITUDE
        //RETORNA O ENDERECO COMPLETO
        public string ObterEndereco(Usuario user)
        {
            string resposta = null;

            try
            {
                using (DataSet ds = new DataSet())
                {

                    string endereco = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y", user.Latitude, user.Longitude);
                    ds.ReadXml(endereco);
                    return ds.Tables["address_component"].Rows[1]["long_name"].ToString() + ", " + ds.Tables["address_component"].Rows[2]["long_name"].ToString() + ", " + ds.Tables["address_component"].Rows[3]["short_name"].ToString();
                }
            }
            catch
            {
                return resposta;
            }
        }

        //MÉTODO RECEBE LATITUDE E LONGITUDE
        //RETORNA O ENDERECO COMPLETO
        public string ObterEndereco(string lat, string lng)
        {
            string resposta = null;

            try
            {
                using (DataSet ds = new DataSet())
                {

                    string endereco = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y", lat, lng);
                    ds.ReadXml(endereco);
                    return ds.Tables["address_component"].Rows[1]["long_name"].ToString() + ", " + ds.Tables["address_component"].Rows[2]["long_name"].ToString() + ", " + ds.Tables["address_component"].Rows[3]["short_name"].ToString();
                }
            }
            catch
            {
                return resposta;
            }
        }

    }
}
