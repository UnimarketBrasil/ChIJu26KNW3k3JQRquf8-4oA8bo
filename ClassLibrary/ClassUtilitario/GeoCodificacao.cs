using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtilitario
{
    public class GeoCodificacao
    {
        public Usuario ObterCoordenadas(Usuario user, string endereco)
        {
            DataSet data = new DataSet();

            try
            {
                string viacep = string.Format("https://viacep.com.br/ws/{0}/xml/", endereco);
                data.ReadXml(viacep);
                string enderecoPorCep = data.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                string googleMaps = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y&new_forward_geocoder=true&address={0}", enderecoPorCep);
                data = new DataSet();
                data.ReadXml(googleMaps);
                user.Latitude = data.Tables["location"].Rows[0]["lat"].ToString();
                user.Longitude = data.Tables["location"].Rows[0]["lng"].ToString();
                data.Dispose();

                return user;

            }
            catch (Exception)
            {

                string googleMaps = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y&new_forward_geocoder=true&address={0}", endereco);
                data = new DataSet();
                data.ReadXml(googleMaps);
                user.Latitude = data.Tables["location"].Rows[0]["lat"].ToString();
                user.Longitude = data.Tables["location"].Rows[0]["lng"].ToString();
                data.Dispose();

                return user;
            }

        }

        public string ObterEndereco(Usuario user)
        {
            string endereco;
            return endereco;
        }
    }
}
