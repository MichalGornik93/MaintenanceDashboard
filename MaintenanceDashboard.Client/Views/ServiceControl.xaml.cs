﻿using System.Windows.Controls;
using System.Threading.Tasks;
using MaintenanceDashbord.Common;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using System;
using System.Windows;
using MaintenanceDashboard.Client.ViewModels;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ServiceControl : UserControl
    {
        public ServiceControl()
        {
            InitializeComponent();
            this.DataContext = new ServiceControlViewModel();
        }

        //private async void button_Click(object sender, RoutedEventArgs e)
        //{

        //    string address = textBox.Text;

        //    await PrintOneLabelTask(address);
        //}

        //private async Task PrintOneLabelTask(string theIpAddress)
        //{
        //    string ZPL_STRING = "^XA^FO10,40^GFA,1937,1937,13,,:::::0018Q06,001EP01E,001F8O02E,0013CO0DE,001EFN037E,001FFCM0DDE,001FFEL01E76,001D6F8K07DFE,001FBBEJ01FE7C,001D7F78I03F7BE,001F4DB4I0FFEFE,001FD6FF003979FE,001F6F7EC0F27DFE,001FE79FD1CFF8FE,001FE3FDE1FDF0FE,001FE0FF8077C0FE,001FE02F001D00FE,001FE008I0E00FE,001FEO0FE,001FAO0FE,001FEO0FE,001FEO0DE,001FEO0FE,001F6O0EE,001F8O03A,001BP01E,001CQ0E,001R02,,:::::0018E1C3F1F98102,001CE1C319818102,001DE36309818102,0017636319F98102,00136373F1818102,001067F331818102,0010641311F9F9F2,00106C1B19F9F9F2,,::::::::V0784,U03F1C,U0JF,03CQ01JF8,12AQ03JF8,22R0780FFE,22AQ0FI0F,42CQ0EI03,451EO01EI01,01408N01C,814P018I01,8A898N0183E,8A924N0107F8,8852O0F0D7BE,85522M01D01A7E,05422N0A03A7A,44722N0AI0238,478A2N0CI0238,I06O08800218,400CN010800218,00104M0104I01,00204N0E604118,202P0200331,202P02,2I08P08002,J08N040407,1001O0401E008,0801O04K08,0801O04,02Q04K04,01008T04,01Q02I02,01004N01I02,J02N018002,00801N01CJ04,008008N06,008004M021EFE1,K02K03FF8001F,K01J01FF7F80FFC,004M040F9JF1FC,004L0100F87F001F0F,004I0400C007CJ01F01,004K03I07CJ01F,L0238I03EK0F008,002I038J03EK0F808,002I018J01FK0F808,002I01CJ01FK0F8,L014J01FK0F804,001I012J01FK0F844,001J02J01F8J0F84,I08I03K0F8J0F862,I08I01K0F8J0F862,I04I01K0F8J0F86,M01K0F8J0F861,I02I01I020F8J0F861,I01I01001F0FCJ0F8E1,J08001007F0FCKF8E,J04001011F8MF8E08,J02001040F9MFDC08,J01FFE100FBFF7FEIFC08,L03E6007IFE857FFC3,L03E8007IF0A07IFC,L01FI03NFC008,M0CI01NFC008,Q01NFC,:Q01BMFC,:::R0BMF8,R0BJFBFFA,R0BJF7FF8,R0BJF7FF9004,R0BJF7FF9002,R0BJF7FF9001,R0BJF0FF9,R0NF88008,:R0NF84,Q01NFC4,Q01NFC2004,Q03NFE1,Q03NFE08,Q01NFC07F6,,::::::^FS^FO150,20^A0,25,25^FDProfessional maintenance^FS^FO200,50^A0,25,25^FDRejestr paletek^FS^FO150,90^BCN,100,Y,N,N^FDPal12^FS^XZ";


        //    await Task.Run(() =>
        //    {

        //        ZebraPrinter zebraPrinter = ZebraPrintHelper.Connect(new TcpConnection(theIpAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT), PrinterLanguage.ZPL); //Połącz, zwraca objekt nawiązanego połaczenia

        //        if (ZebraPrintHelper.CheckStatus(zebraPrinter)) //Jesli jesteś Ready To Print
        //        {
        //            ZebraPrintHelper.Print(zebraPrinter, ZPL_STRING); //Drukuj

        //            if (ZebraPrintHelper.CheckStatusAfter(zebraPrinter))
        //            {
        //                Console.WriteLine($"Label Printed");
        //            }
        //        }

        //        zebraPrinter = ZebraPrintHelper.Disconnect(zebraPrinter);  //Rozłącz
        //        //MessageBox.Show("Done Printing");
        //    });
        //}
    }
}