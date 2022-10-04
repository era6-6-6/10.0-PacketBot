using FunnyProject.Commands;
using Krypton_Core.Managers;
using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.PacketHandlers
{
    public abstract class Client
    {
        TcpClient TcpClient { get; set; }
        NetworkStream? Stream { get; set; }
        
        public Client()
        {
            
            
        }
        public void Send(Command com)
        {
            Send(com.param1.Message.ToArray());
        }
        private void Send(byte[] bytes)
        {
            Stream.Write(bytes, 0, bytes.Length);
        }
        public void Connect(string ip, int port)
        {
            TcpClient = new TcpClient();
            TcpClient.Connect(ip, port);
            if (TcpClient.Connected)
            {
                Stream = TcpClient.GetStream();
                Console.WriteLine("Got stream");
                Task.Run(async () => await ListenForPackets());
                
                return;
            }
        }
        private async Task ListenForPackets()
        {
            try
            {
                while (IsConnected())
                {
                    if (Stream.DataAvailable)
                    {
                        ParsePackets();
                    }
                    
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void ParsePackets()
        {

            try
            {
                if (Stream.Socket.Available > 2)
                {
                    var buffer = new byte[2];
                    Stream.Read(buffer, 0, 2);
                    var reader = new EndianBinaryReader(EndianBitConverter.Big, new MemoryStream(buffer));

                    int streamLength = (ushort)reader.ReadInt16();
                    if (streamLength > 0)
                    {
                        buffer = new byte[streamLength];

                        int offset = 0, rcvd = 0;
                        while (offset + 1 < streamLength)
                        {

                            rcvd = Stream.Read(buffer, offset, streamLength - offset);
                            offset += rcvd;

                            
                        }
                        reader = new EndianBinaryReader(EndianBitConverter.Big, new MemoryStream(buffer));
                        
                        Parse(new EndianBinaryReader(EndianBitConverter.Big, new MemoryStream(buffer)));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected bool IsConnected()
        {
            if (TcpClient == null || TcpClient.Client == null || !Stream.CanWrite || !Stream.CanRead)
                return false;
            try
            {
                return !(TcpClient.Client.Poll(1, SelectMode.SelectRead) && TcpClient.Client.Available == 0);
            }
            catch (SocketException) { return false; }
        }

        public abstract void Parse(EndianBinaryReader read);
    }
    

}
