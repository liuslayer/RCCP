using DatabaseConfiguration.CommandFunction;
using DatabaseConfiguration.DeviceEntitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConfiguration.Tables_From
{
    public partial class ConfigFacilityInformationInfo : Form
    {
        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        List<StreamMediaList> tmpListStreamMedia;
        StreamMedia_Command tmpStreamMediaCommand = new StreamMedia_Command();

        List<CameraList> tmpListCamera;
        Camera_Command tmpCamera_Command = new Camera_Command();

        List<UPSList> tmpListUPS;
        UPSData_Command tmpUPSData_Command = new UPSData_Command();

        List<TurnTableList> tmpListTurnTable;
        TurnTable_Command tmpTurnTableCommand = new TurnTable_Command();

        List<SolarEnergyList> tmpListSolarEnergy;
        SolarEnergy_Command tmpSolarEnergyCommand = new SolarEnergy_Command();

        List<RadarList> tmpListRadar;
        Radar_Command tmpRadarCommand = new Radar_Command();

        List<ComputerList> tmpListComputer;
        Computer_Command tmpComputerCommand = new Computer_Command();

        List<ServerList> tmpListServer;
        Server_Command tmpServerCommand = new Server_Command();

        List<VibrationCableList> tmpListVibrationCable;
        VibrationCable_Command tmpVibrationCableCommand = new VibrationCable_Command();

        public ConfigFacilityInformationInfo()
        {
            InitializeComponent();
            GetFacilityInformationList();

        }
        public void GetFacilityInformationList()
        {
            tmpListStation = tmpStationCommand._QueryData();
            tmpListStreamMedia = tmpStreamMediaCommand._QueryData();
            tmpListCamera = tmpCamera_Command._QueryData();
            tmpListUPS = tmpUPSData_Command._QueryData();
            tmpListTurnTable = tmpTurnTableCommand._QueryData();
            tmpListSolarEnergy = tmpSolarEnergyCommand._QueryData();
            tmpListRadar = tmpRadarCommand._QueryData();
            tmpListComputer = tmpComputerCommand._QueryData();
            tmpListServer = tmpServerCommand._QueryData();
            tmpListVibrationCable = tmpVibrationCableCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListStation != null)
            {
                int StreamMediaNumber, CameraNumber, UPSNumber, TurnTableNumber, SolarEnergyNumber, RadarNumber;
                int ComputerNumber, ServerNumber, VibrationCableNumber;
                for (int i = 0; i < tmpListStation.Count; i++)
                {
                    StreamMediaNumber = 0; CameraNumber = 0; UPSNumber = 0;
                    TurnTableNumber = 0; SolarEnergyNumber = 0; RadarNumber = 0;
                    ComputerNumber = 0; ServerNumber = 0; VibrationCableNumber = 0;
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListStation[i].Name;

                    //流媒体
                    if (tmpListStreamMedia != null)
                    {
                        for (int j = 0; j < tmpListStreamMedia.Count; j++)
                        {
                            if (tmpListStation[i].StationID == tmpListStreamMedia[j].StationID)
                            {
                                StreamMediaNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[1].Value = StreamMediaNumber;

                    //摄像机
                    if (tmpListCamera != null)
                    {
                        for (int k = 0; k < tmpListCamera.Count; k++)
                        {
                            for(int ki =0; ki < tmpListStreamMedia.Count; ki++)
                            {
                                if(tmpListCamera[k].StreamMedia_DeviceID== tmpListStreamMedia[ki].DeviceID)
                                {
                                    if(tmpListStreamMedia[ki].StationID == tmpListStation[i].StationID)
                                    {
                                        CameraNumber++;
                                    }
                                }
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[2].Value = CameraNumber;

                    //UPS
                    if (tmpListUPS != null)
                    {
                        for (int l = 0; l < tmpListUPS.Count; l++)
                        {
                            if (tmpListUPS[l].StationID == tmpListStation[i].StationID)
                            {
                                UPSNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = UPSNumber;

                    //转台/云台
                    if (tmpListTurnTable != null)
                    {
                        for (int m = 0; m < tmpListTurnTable.Count; m++)
                        {
                            if (tmpListTurnTable[m].StationID == tmpListStation[i].StationID)
                            {
                                TurnTableNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[4].Value = TurnTableNumber;

                    //太阳能
                    if (tmpListSolarEnergy != null)
                    {
                        for (int n = 0; n < tmpListSolarEnergy.Count; n++)
                        {
                            if (tmpListSolarEnergy[n].StationID == tmpListStation[i].StationID)
                            {
                                SolarEnergyNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[5].Value = SolarEnergyNumber;

                    //雷达
                    if (tmpListRadar != null)
                    {
                        for (int o = 0; o < tmpListRadar.Count; o++)
                        {
                            if(tmpListRadar[o].StationID == tmpListStation[i].StationID)
                            {
                                RadarNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[5].Value = RadarNumber;

                    //计算机
                    if (tmpListComputer != null)
                    {
                        for (int p = 0; p < tmpListComputer.Count; p++)
                        {
                            if (tmpListComputer[p].StationID == tmpListStation[i].StationID)
                            {
                                ComputerNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[6].Value = ComputerNumber;

                    //服务器
                    if (tmpListServer != null)
                    {
                        for (int q = 0; q < tmpListServer.Count; q++)
                        {
                            if(tmpListServer[q].StationID == tmpListStation[i].StationID)
                            {
                                ServerNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[7].Value = ServerNumber;

                    //报警设备
                    if(tmpListVibrationCable !=null)
                    {
                        for (int r = 0; r < tmpListVibrationCable.Count; r++)
                        {
                            if(tmpListVibrationCable[r].StationID == tmpListStation[i].StationID)
                            {
                                VibrationCableNumber++;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[8].Value = VibrationCableNumber;
                }
            }
        }
    }
}
