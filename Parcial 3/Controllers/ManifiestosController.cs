using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Parcial_3.Models;
using System.Net.Http.Headers;

namespace Parcial_3.Controllers
{
    public class ManifiestosController : Controller
    {
        // GET: Manifiestos
        // GET: Sucursules
        string Baseurl = "http://localhost:61212/api/shipment/";
        public async Task<ActionResult> Index()
        {
            List<ManifiestoModel> manifiestosList = new List<ManifiestoModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    manifiestosList = JsonConvert.DeserializeObject<List<ManifiestoModel>>(EmpResponse);

                }
                return View(manifiestosList);
            }
        }

        public async Task<ActionResult> Create()
        {
            string clientsURL = "http://localhost:61212/api/client/";
            List<ClientModel> clientes = new List<ClientModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(clientsURL);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    clientes = JsonConvert.DeserializeObject<List<ClientModel>>(EmpResponse);
                    ViewBag.Clientes = clientes;
                }
            }
            string wareHouseURL = "http://localhost:61212/api/warehouse/";
            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            using (var warehouse = new HttpClient())
            {
                warehouse.BaseAddress = new Uri(wareHouseURL);
                warehouse.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await warehouse.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    warehouseList = JsonConvert.DeserializeObject<List<WarehouseModel>>(EmpResponse);
                    ViewBag.Warehouse = warehouseList;
                }
            }

            string branchOfficeURL = "http://localhost:61212/api/branchoffice/";
            List<SucursalesModel>  branchOfficeList = new List<SucursalesModel>();
            using (var branchoffice = new HttpClient())
            {
                branchoffice.BaseAddress = new Uri(branchOfficeURL);
                branchoffice.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await branchoffice.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    branchOfficeList = JsonConvert.DeserializeObject<List<SucursalesModel>>(EmpResponse);
                    ViewBag.BranchOffice = branchOfficeList;
                }
            }

            string departmentURL = "http://localhost:61212/api/department/";
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            using (var department = new HttpClient())
            {
                department.BaseAddress = new Uri(departmentURL);
                department.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await department.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    departmentList = JsonConvert.DeserializeObject<List<DepartmentModel>>(EmpResponse);
                    ViewBag.Department = departmentList;
                }
            }

            return View();
        }

        public async Task<ActionResult> CreatePost(int id_client, string tracking_number, int id_warehouse_dest, int id_branchoffice, int id_department, int active)
        {
            string CreateManifiestosurl = "http://localhost:61212/api/shipment/";
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(CreateManifiestosurl);
                    client.DefaultRequestHeaders.Clear();
                    ManifiestoModel manifiestos = new ManifiestoModel();
                    manifiestos.id_client = id_client;
                    manifiestos.tracking_number = tracking_number;
                    manifiestos.id_warehouse_dest = id_warehouse_dest;
                    manifiestos.id_branchoffice = id_branchoffice;
                    manifiestos.id_department = id_department;
                    manifiestos.active = active;
                    var myContent = JsonConvert.SerializeObject(manifiestos);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage Res = await client.PostAsync(Baseurl, byteContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        Console.Write(Res);
                        return Content("1");
                    }
                    Console.Write(Res);
                    return Content("0");
                }

            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }

        public async Task<ActionResult> Update(int id)
        {
            string clientsURL = "http://localhost:61212/api/client/";
            List<ClientModel> clientes = new List<ClientModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(clientsURL);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    clientes = JsonConvert.DeserializeObject<List<ClientModel>>(EmpResponse);
                    ViewBag.Clientes = clientes;
                }
            }
            string wareHouseURL = "http://localhost:61212/api/warehouse/";
            List<WarehouseModel> warehouseList = new List<WarehouseModel>();
            using (var warehouse = new HttpClient())
            {
                warehouse.BaseAddress = new Uri(wareHouseURL);
                warehouse.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await warehouse.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    warehouseList = JsonConvert.DeserializeObject<List<WarehouseModel>>(EmpResponse);
                    ViewBag.Warehouse = warehouseList;
                }
            }

            string branchOfficeURL = "http://localhost:61212/api/branchoffice/";
            List<SucursalesModel> branchOfficeList = new List<SucursalesModel>();
            using (var branchoffice = new HttpClient())
            {
                branchoffice.BaseAddress = new Uri(branchOfficeURL);
                branchoffice.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await branchoffice.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    branchOfficeList = JsonConvert.DeserializeObject<List<SucursalesModel>>(EmpResponse);
                    ViewBag.BranchOffice = branchOfficeList;
                }
            }

            string departmentURL = "http://localhost:61212/api/department/";
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            using (var department = new HttpClient())
            {
                department.BaseAddress = new Uri(departmentURL);
                department.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await department.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    departmentList = JsonConvert.DeserializeObject<List<DepartmentModel>>(EmpResponse);
                    ViewBag.Department = departmentList;
                }
            }

            string shipmentStatusURL = "http://localhost:61212/api/shipmentstatus/";
            List<ShipmentStatusModel> shipmentStatusList = new List<ShipmentStatusModel>();
            using (var shipmentStatus = new HttpClient())
            {
                shipmentStatus.BaseAddress = new Uri(shipmentStatusURL);
                shipmentStatus.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await shipmentStatus.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    shipmentStatusList = JsonConvert.DeserializeObject<List<ShipmentStatusModel>>(EmpResponse);
                    ViewBag.ShipmentStatus = shipmentStatusList;
                }
            }

            string paymentTypeURL = "http://localhost:61212/api/paymenttype/";
            List<PaymentTypeModel> paymentTypeList = new List<PaymentTypeModel>();
            using (var shipmentStatus = new HttpClient())
            {
                shipmentStatus.BaseAddress = new Uri(paymentTypeURL);
                shipmentStatus.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await shipmentStatus.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    paymentTypeList = JsonConvert.DeserializeObject<List<PaymentTypeModel>>(EmpResponse);
                    ViewBag.PaymentType = paymentTypeList;
                }
            }

            string CreateManifiestosurl = "http://localhost:61212/api/shipment/"+id;
            
                using (var client = new HttpClient())
                {
                    ManifiestoModel manifiestos = new ManifiestoModel();
                    client.BaseAddress = new Uri(CreateManifiestosurl);
                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                    {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    manifiestos = JsonConvert.DeserializeObject<ManifiestoModel>(EmpResponse);
                    ViewBag.idCliente = manifiestos.id_client;
                    ViewBag.idWarehouse = manifiestos.id_warehouse_dest;
                    ViewBag.idBranchOffice = manifiestos.id_branchoffice;
                    ViewBag.idDepartment = manifiestos.id_department;
                    ViewBag.active = manifiestos.active;
                    ViewBag.idShipment = id;
                    ViewBag.idShipmentStatus = manifiestos.shipment_status;
                    ViewBag.ArrivalWarehouseDate = manifiestos.arrival_warehouse_date;
                    ViewBag.ArrivalBranchOfficeDate = manifiestos.arrival_branchoffice;
                    ViewBag.ClientSendDate = manifiestos.client_send_date;
                    ViewBag.FailedAttempt = manifiestos.failed_attempt;
                    ViewBag.idPaymentType = manifiestos.payment_type;
                    ViewBag.FailedAttempt = manifiestos.failed_attempt;
                }
                    return View();
                }


        }
    }
}