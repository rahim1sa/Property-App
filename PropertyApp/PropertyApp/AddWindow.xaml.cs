using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PropertyApp.Model;

namespace PropertyApp
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        PropetyAppEntities db = new PropetyAppEntities();
        Property selected = new Property();


        public AddWindow()
        {
            InitializeComponent();
            FillDataGrid();
            FillStatus();
            FillAdvertType();
            FillPropertyType();
            FillCountry();
            FillCities();
            FillRegions();
            FillSettlements();
            FillMetro();
            FillConstProject();
            FillFloorCount();
            FillRoomCount();
            FillDocType();
            FillRepairType();
            FillSellType();
            FillOwnerType();
        }

        //Filling DataGridView
        private void FillDataGrid()
        {
            //dgvProps.Items.Clear();
            foreach (Property item in db.Properties.ToList())
            {
                
                PropertyView obj = new PropertyView
                {
                    Id = item.Id,
                    StatusType = item.Status.StatusName,
                    AdvertType = item.Advert_Type.Name,
                    PropertyType = item.Propert_Type.Name,
                    RoomCount = item.Room_Count.RoomCount,
                    City = item.City.CityName,
                    Region = item.Region.RegionName,
                    Settlement = item.Settlement.Name,
                    Country = item.Country.Name,
                    DocumentType = item.Document_Type.Name,
                    RepairType = item.Repair_Type.Name,
                    SellType = item.Sell_Type.Name,
                    Metro = item.Metro.MetroName,
                    OwnerType = item.Owner_Type.TypeName,
                    FloorCount = item.Floor_Count.FloorCount,
                    ConstProject = item.Constructor_Project.ProjectName,
                    Adress = item.Adress,
                    Price = (int)item.Price,
                    About = item.About,
                    OwnerName = item.OwnerName,
                    OwnerNumber = item.OwnerNumber,
                    OwnerEmail = item.OwnerEmail,
                    OwnerAbout = item.OwnerAbout,
                    Area = (decimal)item.Area,
                    Floor = item.Floor.ToString(),
                    LandArea = (decimal)item.LandArea
                };
                dgvProps.Items.Add(obj);
               
            }
            

        }

        //--=----=-----=-----=-----=-----=----=----=-----=-----=-----=-----=---=----=-----=-----=-----=-----=

        //Filling Status Combobox
        private void FillStatus()
        {
            cmbStatusType.Items.Add("Seçin");
            foreach (Status item in db.Status.ToList())
            {
                cmbStatusType.Items.Add(item.Id + "-" + item.StatusName.ToString());
            }
        }
        //Filling advert(elan) type Combobox
        private void FillAdvertType()
        {
            cmbAdvertType.Items.Add("Seçin");
            foreach (Advert_Type item in db.Advert_Type.ToList())
            {
                cmbAdvertType.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        //Filling Property type Combobox
        private void FillPropertyType()
        {
            cmbPropertyType.Items.Add("Seçin");
            foreach (Propert_Type item in db.Propert_Type.ToList())
            {
                cmbPropertyType.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        //Filling Country Combobox
        private void FillCountry()
        {
            cmbCountry.Items.Add("Seçin");
            foreach (Country item in db.Countries.ToList())
            {
                cmbCountry.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        //Filling City Combobox
        private void FillCities()
        {
            cmbCities.Items.Add("Seçin");
            foreach (City item in db.Cities.ToList())
            {
                cmbCities.Items.Add(item.Id + "-" + item.CityName.ToString());
            }
        }
        //Filling Region Combobox
        private void FillRegions()
        {
            cmbRegions.Items.Add("Seçin");
            foreach (Region item in db.Regions.ToList())
            {
                cmbRegions.Items.Add(item.Id + "-" + item.RegionName.ToString());
            }
        }
        //Filling Settlement Combobox
        private void FillSettlements()
        {
            cmbSettlement.Items.Add("Seçin");
            foreach (Settlement item in db.Settlements.ToList())
            {
                cmbSettlement.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        //Filling Metro Combobox
        private void FillMetro()
        {
            cmbMetro.Items.Add("Seçin");
            foreach (Metro item in db.Metroes.ToList())
            {
                cmbMetro.Items.Add(item.Id + "-" + item.MetroName.ToString());
            }
        }
        //Filling Owner Type Combobox
        private void FillOwnerType()
        {
            cmbOwnerType.Items.Add("Seçin");
            foreach (Owner_Type item in db.Owner_Type.ToList())
            {
                cmbOwnerType.Items.Add(item.Id + "-" + item.TypeName.ToString());
            }
        }
        //Filling Constructor Project(Bina proyekti) Combobox
        private void FillConstProject()
        {

            cmbConstProject.Items.Add("Seçin");
            foreach (Constructor_Project item in db.Constructor_Project.ToList())
            {
                cmbConstProject.Items.Add(item.Id + "-" + item.ProjectName.ToString());
            }
        }
        //Filling Floor Count Combobox
        private void FillFloorCount()
        {
            cmbFloorCount.Items.Add("Seçin");
            foreach (Floor_Count item in db.Floor_Count.ToList())
            {
                cmbFloorCount.Items.Add(item.FloorCount.ToString());
            }
        }
        //Filling Floor Combobox
        private void cmbFloorCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItem = Convert.ToInt32(cmbFloorCount.SelectedIndex.ToString());

            foreach (Floor_Count item in db.Floor_Count.ToList())
            {
                if (selectedItem.ToString() != "Seçin")
                {
                    if (Convert.ToInt32(item.FloorCount.ToString()) <= selectedItem)
                    {
                        cmbFloor.Items.Add(item.FloorCount.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        //Filling Room Count Combobox
        private void FillRoomCount()
        {

            cmbRoomCount.Items.Add("Seçin");
            foreach (Room_Count item in db.Room_Count.ToList())
            {
                cmbRoomCount.Items.Add(item.RoomCount);
            }
        }
        //Filling Document Type Combobox
        private void FillDocType()
        {

            cmbDocumentType.Items.Add("Seçin");
            foreach (Document_Type item in db.Document_Type.ToList())
            {
                cmbDocumentType.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        //Filling Repair Type Combobox
        private void FillRepairType()
        {

            cmbRepairType.Items.Add("Seçin");
            foreach (Repair_Type item in db.Repair_Type.ToList())
            {
                cmbRepairType.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }
        
        //Filling Sell Type Combobox
        private void FillSellType()
        {

            cmbSellType.Items.Add("Seçin");
            foreach (Sell_Type item in db.Sell_Type.ToList())
            {
                cmbSellType.Items.Add(item.Id + "-" + item.Name.ToString());
            }
        }

        // RESET FUNCTION ////
        private void Reset()
        {
            cmbStatusType.Text = "";
            cmbAdvertType.Text = "";
            cmbPropertyType.Text = "";
            cmbMetro.Text = "";
            cmbCities.Text = "";
            new TextRange(rtbAdress.Document.ContentStart, rtbAdress.Document.ContentEnd).Text = "";
            cmbRegions.Text = "";
            cmbSettlement.Text = "";
            cmbOwnerType.Text = "";
            cmbCountry.Text = "";
            cmbFloorCount.Text = "";
            cmbFloor.Text = "";
            cmbRoomCount.Text = "";
            txtArea.Text = "";
            txtPrice.Text = "";
            cmbDocumentType.Text = "";
            new TextRange(rtbAbout.Document.ContentStart, rtbAbout.Document.ContentEnd).Text = "";
            cmbConstProject.Text = "";
            cmbRepairType.Text = "";
            txtLandArea.Text = "";
            cmbSellType.Text = "";
            txtOwnerName.Text = "";
            txtOwnerNumber.Text = "";
            txtOwnerEmail.Text = "";
            txtOwnerAbout.Text = "";

           
            FillDataGrid();
            
        }

        // ADD Function //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string statusType = cmbStatusType.Text;
            string advertType = cmbAdvertType.Text;
            string propertyType = cmbPropertyType.Text;
            string metro = cmbMetro.Text;
            string city = cmbCities.Text;
            string adress = new TextRange(rtbAdress.Document.ContentStart, rtbAdress.Document.ContentEnd).Text;
            string region = cmbRegions.Text;
            string settlement = cmbSettlement.Text;
            string ownerType = cmbOwnerType.Text;
            string country = cmbCountry.Text;
            string floorCount = cmbFloorCount.Text;
            string floor = cmbFloor.Text;
            string roomCount = cmbRoomCount.Text;
            decimal area = Convert.ToDecimal(txtArea.Text);
            int price = Convert.ToInt32(txtPrice.Text);
            string documentType = cmbDocumentType.Text;
            string about = new TextRange(rtbAbout.Document.ContentStart, rtbAbout.Document.ContentEnd).Text;
            string constProject = cmbConstProject.Text;
            string repairType = cmbRepairType.Text;
            decimal landArea = Convert.ToDecimal(txtLandArea.Text);
            string sellType = cmbSellType.Text;
            string ownerName = txtOwnerName.Text;
            string ownerNumber = txtOwnerNumber.Text;
            string ownerEmail = txtOwnerEmail.Text;
            string ownerAbout = txtOwnerAbout.Text;


            if (statusType == string.Empty || advertType == string.Empty || propertyType == string.Empty || city == string.Empty || region == string.Empty || adress == string.Empty || floorCount == string.Empty || floor == string.Empty || roomCount == string.Empty || ownerName == string.Empty || ownerNumber == string.Empty || ownerType == string.Empty)
            {
                lblError.Visibility = Visibility.Visible;
                return;
            }

            Property prp = new Property
            {
                StatusId = Convert.ToInt32(statusType.Split('-')[0]),
                AdvertTypeId = Convert.ToInt32(advertType.Split('-')[0]),
                PropertyTypeId = Convert.ToInt32(propertyType.Split('-')[0]),
                CityId = Convert.ToInt32(city.Split('-')[0]),
                Adress = adress,
                RegionId = Convert.ToInt32(region.Split('-')[0]),
                SettlementId = Convert.ToInt32(settlement.Split('-')[0]),
                MetroId = Convert.ToInt32(metro.Split('-')[0]),
                OwnerTypeId = Convert.ToInt32(ownerType.Split('-')[0]),
                CountryId = Convert.ToInt32(country.Split('-')[0]),
                FloorCountId = Convert.ToInt32(floorCount),
                Floor = Convert.ToInt32(floor),
                RoomCountId = Convert.ToInt32(roomCount.Split('-')[0]),
                Area = area,
                Price = price,
                DocumentTypeId = Convert.ToInt32(documentType.Split('-')[0]),
                About = about,
                ConstProjectId = Convert.ToInt32(constProject.Split('-')[0]),
                RepairTypeId = Convert.ToInt32(repairType.Split('-')[0]),
                LandArea = landArea,
                SellTypeId = Convert.ToInt32(sellType.Split('-')[0]),
                OwnerName = ownerName,
                OwnerNumber = ownerNumber,
                OwnerEmail = ownerEmail,
                OwnerAbout = ownerAbout
            };
            db.Properties.Add(prp);
            db.SaveChanges();
            Reset();
        }
        // SELECTING DATAGRID ROW
        private void dgvProps_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            PropertyView prop = dgvProps.CurrentItem as PropertyView;
            selected = db.Properties.Find(prop.Id);
            
            cmbStatusType.Text = selected.StatusId + "-" + selected.Status.StatusName;
            cmbAdvertType.Text = selected.AdvertTypeId + "-" + selected.Advert_Type.Name;
            cmbPropertyType.Text = selected.PropertyTypeId + "-" + selected.Propert_Type.Name;
            cmbCities.Text = selected.CityId + "-" + selected.City.CityName;
            new TextRange(rtbAdress.Document.ContentStart, rtbAdress.Document.ContentEnd).Text = selected.Adress;
            cmbRegions.Text = selected.RegionId + "-" + selected.Region.RegionName;
            cmbSettlement.Text = selected.SettlementId + "-" + selected.Settlement.Name;
            cmbMetro.Text = selected.MetroId + "-" + selected.Metro.MetroName;
            cmbOwnerType.Text = selected.OwnerTypeId + "-" + selected.Owner_Type.TypeName;
            cmbCountry.Text =selected.CountryId + "-" + selected.Country.Name;
            cmbFloorCount.Text = selected.Floor_Count.FloorCount;
            cmbFloor.Text = selected.Floor.ToString();
            cmbRoomCount.Text = selected.Room_Count.RoomCount;
            txtArea.Text= selected.Area.ToString();
            txtPrice.Text = selected.Price.ToString();
            cmbDocumentType.Text = selected.DocumentTypeId + "-" + selected.Document_Type.Name;
            new TextRange(rtbAbout.Document.ContentStart, rtbAbout.Document.ContentEnd).Text = selected.About;
            cmbConstProject.Text = selected.ConstProjectId + "-" + selected.Constructor_Project.ProjectName;
            cmbRepairType.Text = selected.RepairTypeId + "-" + selected.Repair_Type.Name;
            txtLandArea.Text = selected.LandArea.ToString();
            cmbSellType.Text = selected.SellTypeId + "-" + selected.Sell_Type.Name;
            txtOwnerName.Text = selected.OwnerName;
            txtOwnerNumber.Text = selected.OwnerNumber;
            txtOwnerEmail.Text = selected.OwnerEmail;
            txtOwnerAbout.Text = selected.OwnerAbout;

            btnAdd.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
        }


        // UPDATE Function //
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            string statusType = cmbStatusType.Text.Split('-')[1];
            string advertType = cmbAdvertType.Text.Split('-')[1];
            string propertyType = cmbPropertyType.Text.Split('-')[1];
            string city = cmbCities.Text.Split('-')[1];
            string adress = new TextRange(rtbAdress.Document.ContentStart, rtbAdress.Document.ContentEnd).Text;
            string region = cmbRegions.Text.Split('-')[1];
            int settlement = Convert.ToInt32(cmbSettlement.Text.Split('-')[0]);
            string metro = cmbMetro.Text.Split('-')[1];
            string ownerType = cmbOwnerType.Text.Split('-')[1];
            string country = cmbCountry.Text.Split('-')[1];
            string floorCount = cmbFloorCount.Text;
            string floor = cmbFloor.Text;
            string roomCount = cmbRoomCount.Text;
            decimal area = Convert.ToDecimal(txtArea.Text);
            int price = Convert.ToInt32(txtPrice.Text);
            string documentType = cmbDocumentType.Text.Split('-')[1];
            string about = new TextRange(rtbAbout.Document.ContentStart, rtbAbout.Document.ContentEnd).Text;
            string constProject = cmbConstProject.Text.Split('-')[1];
            string repairType = cmbRepairType.Text.Split('-')[1];
            decimal landArea = Convert.ToDecimal(txtLandArea.Text);
            string sellType = cmbSellType.Text.Split('-')[1];
            string ownerName = txtOwnerName.Text;
            string ownerNumber = txtOwnerNumber.Text;
            string ownerEmail = txtOwnerEmail.Text;
            string ownerAbout = txtOwnerAbout.Text;

            int statusId = db.Status.FirstOrDefault(s => s.StatusName == statusType).Id;
            int advertId = db.Advert_Type.FirstOrDefault(s => s.Name == advertType).Id;
            int propertyId = db.Propert_Type.FirstOrDefault(s => s.Name == propertyType).Id;
            int roomCountId = db.Room_Count.FirstOrDefault(s => s.RoomCount == roomCount).Id;
            int cityId = db.Cities.FirstOrDefault(s => s.CityName == city).Id;
            int regionId = db.Regions.FirstOrDefault(s => s.RegionName == region).Id;
            int settlementId = db.Settlements.Find(settlement).Id;
            int countryId = db.Countries.FirstOrDefault(s => s.Name == country).Id;
            int documentId = db.Document_Type.FirstOrDefault(s => s.Name == documentType).Id;
            int repairId = db.Repair_Type.FirstOrDefault(s => s.Name == repairType).Id;
            int sellId = db.Sell_Type.FirstOrDefault(s => s.Name == sellType).Id;
            int metroId = db.Metroes.FirstOrDefault(s => s.MetroName == metro).Id;
            int ownerTypeId = db.Owner_Type.FirstOrDefault(s => s.TypeName == ownerType).Id;
            int floorCountId = db.Floor_Count.FirstOrDefault(s => s.FloorCount == floorCount).Id;
            int constProjectId = db.Constructor_Project.FirstOrDefault(s => s.ProjectName == constProject).Id;


            selected.StatusId = statusId;
            selected.AdvertTypeId = advertId;
            selected.PropertyTypeId = propertyId;
            selected.RoomCountId = roomCountId;
            selected.CityId = cityId;
            selected.RegionId = regionId;
            selected.SettlementId = settlementId;
            selected.CountryId = countryId;
            selected.DocumentTypeId = documentId;
            selected.RepairTypeId = repairId;
            selected.SellTypeId = sellId;
            selected.MetroId = metroId;
            selected.OwnerTypeId = ownerTypeId;
            selected.FloorCountId = floorCountId;
            selected.ConstProjectId = constProjectId;
            selected.Adress = selected.Adress;
            selected.Price = selected.Price;
            selected.About = selected.About;
            selected.OwnerName = selected.OwnerName;
            selected.OwnerNumber = selected.OwnerNumber;
            selected.OwnerEmail = selected.OwnerEmail;
            selected.OwnerAbout = selected.OwnerAbout;
            selected.Area = selected.Area;
            selected.Floor = Convert.ToInt32(selected.Floor);
            selected.LandArea = selected.LandArea;

            db.SaveChanges();
            Reset();
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //string statusType = cmbStatusType.Text.Split('-')[1];
            //string advertType = cmbAdvertType.Text.Split('-')[1];
            //string propertyType = cmbPropertyType.Text.Split('-')[1];
            //string city = cmbCities.Text.Split('-')[1];
            //string adress = new TextRange(rtbAdress.Document.ContentStart, rtbAdress.Document.ContentEnd).Text;
            //string region = cmbRegions.Text.Split('-')[1];
            //int settlement = Convert.ToInt32(cmbSettlement.Text.Split('-')[0]);
            //string metro = cmbMetro.Text.Split('-')[1];
            //string ownerType = cmbOwnerType.Text.Split('-')[1];
            //string country = cmbCountry.Text.Split('-')[1];
            //string floorCount = cmbFloorCount.Text;
            //string floor = cmbFloor.Text;
            //string roomCount = cmbRoomCount.Text;
            //decimal area = Convert.ToDecimal(txtArea.Text);
            //int price = Convert.ToInt32(txtPrice.Text);
            //string documentType = cmbDocumentType.Text.Split('-')[1];
            //string about = new TextRange(rtbAbout.Document.ContentStart, rtbAbout.Document.ContentEnd).Text;
            //string constProject = cmbConstProject.Text.Split('-')[1];
            //string repairType = cmbRepairType.Text.Split('-')[1];
            //decimal landArea = Convert.ToDecimal(txtLandArea.Text);
            //string sellType = cmbSellType.Text.Split('-')[1];
            //string ownerName = txtOwnerName.Text;
            //string ownerNumber = txtOwnerNumber.Text;
            //string ownerEmail = txtOwnerEmail.Text;
            //string ownerAbout = txtOwnerAbout.Text;

            //int statusId = db.Status.FirstOrDefault(s => s.StatusName == statusType).Id;
            //int advertId = db.Advert_Type.FirstOrDefault(s => s.Name == advertType).Id;
            //int propertyId = db.Propert_Type.FirstOrDefault(s => s.Name == propertyType).Id;
            //int roomCountId = db.Room_Count.FirstOrDefault(s => s.RoomCount == roomCount).Id;
            //int cityId = db.Cities.FirstOrDefault(s => s.CityName == city).Id;
            //int regionId = db.Regions.FirstOrDefault(s => s.RegionName == region).Id;
            //int settlementId = db.Settlements.Find(settlement).Id;
            //int countryId = db.Countries.FirstOrDefault(s => s.Name == country).Id;
            //int documentId = db.Document_Type.FirstOrDefault(s => s.Name == documentType).Id;
            //int repairId = db.Repair_Type.FirstOrDefault(s => s.Name == repairType).Id;
            //int sellId = db.Sell_Type.FirstOrDefault(s => s.Name == sellType).Id;
            //int metroId = db.Metroes.FirstOrDefault(s => s.MetroName == metro).Id;
            //int ownerTypeId = db.Owner_Type.FirstOrDefault(s => s.TypeName == ownerType).Id;
            //int floorCountId = db.Floor_Count.FirstOrDefault(s => s.FloorCount == floorCount).Id;
            //int constProjectId = db.Constructor_Project.FirstOrDefault(s => s.ProjectName == constProject).Id;

            //Property newSelected = new Property
            //{
            //    Id = selected.Id,
            //    StatusId = statusId,
            //    AdvertTypeId = advertId,
            //    PropertyTypeId = propertyId,
            //    RoomCountId = roomCountId,
            //    CityId = cityId,
            //    RegionId = regionId,
            //    SettlementId = settlementId,
            //    CountryId = countryId,
            //    DocumentTypeId = documentId,
            //    RepairTypeId = repairId,
            //    SellTypeId = sellId,
            //    MetroId = metroId,
            //    OwnerTypeId = ownerTypeId,
            //    FloorCountId = floorCountId,
            //    ConstProjectId = constProjectId,
            //    Adress = selected.Adress,
            //    Price = selected.Price,
            //    About = selected.About,
            //    OwnerName = selected.OwnerName,
            //    OwnerNumber = selected.OwnerNumber,
            //    OwnerEmail = selected.OwnerEmail,
            //    OwnerAbout = selected.OwnerAbout,
            //    Area = selected.Area,
            //    Floor = Convert.ToInt32(selected.Floor),
            //    LandArea = selected.LandArea
            //};
            MessageBoxResult r = MessageBox.Show("Eminsiniz mi?", "Silme", MessageBoxButton.OKCancel);
            if (r == MessageBoxResult.OK)
            {
                db.Properties.Remove(selected);
                db.SaveChanges();
                Reset();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            btnAdd.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
        }



        //==================================================================================================



    }
}
