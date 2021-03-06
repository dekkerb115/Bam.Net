﻿using Bam.Net.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.Server.Streaming
{
    public class StreamingClient<TRequest, TResponse>: StreamingClient
    {
        public StreamingClient(string hostName, int port) : base(hostName, port) { }

        public StreamingResponse<TResponse> SendRequest(TRequest message)
        {
            StreamingRequest<TRequest> request = new StreamingRequest<TRequest> { Message = message };
            SendRequest(request);
            return ReceiveResponse<StreamingResponse<TResponse>>(NetworkStream);
        }
    }

    public class StreamingClient: Loggable
    {
        TcpClient _client;
        public StreamingClient(string hostName, int port)
        {
            HostName = hostName;
            Port = port;
            _client = new TcpClient(HostName, Port);
            Connect();
        }

        public void Connect()
        {
            NetworkStream = _client.GetStream();
        }

        public string HostName { get; set; }
        public int Port { get; set; }

        protected NetworkStream NetworkStream { get; set; }

        public StreamingResponse SendRequest(object message)
        {
            SendRequest(NetworkStream, message);
            return ReceiveResponse<StreamingResponse>(NetworkStream);
        }

        protected T ReceiveResponse<T>(Stream stream)
        {
            byte[] first = new byte[4];
            stream.Read(first, 0, 4);
            int length = BitConverter.ToInt32(first, 0);
            byte[] responseBytes = new byte[length];
            stream.Read(responseBytes, 0, length);
            return responseBytes.FromBinaryBytes<T>();
        }

        private void SendRequest(Stream stream, object message)
        {
            StreamingRequest msg = new StreamingRequest { Message = message };
            SendRequest(stream, msg);
        }

        private static void SendRequest(Stream stream, StreamingRequest msg)
        {
            byte[] binMsg = msg.ToBinaryBytes();
            List<byte> sendMsg = new List<byte>();
            sendMsg.AddRange(BitConverter.GetBytes(binMsg.Length));
            sendMsg.AddRange(binMsg);
            byte[] sendBytes = sendMsg.ToArray();
            stream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}
