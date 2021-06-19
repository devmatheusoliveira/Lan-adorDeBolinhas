using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
 
public class testando : MonoBehaviour
{
    [SerializeField] private string serverIp = "170.83.206.228";
    [SerializeField] private int serverPort = 8000;
 
    /// <summary>
    /// Server
    /// </summary>
    TcpListener listener;
    StreamWriter writer;
 
    /// <summary>
    /// It appears when to connect a StreamReader to a client it must continue using that specific StreamReader?
    /// </summary>
    List<TcpClient> connectedClients = new List<TcpClient>();
    List<StreamReader> connectedClientReaders = new List<StreamReader>();
 
    private void Awake()
    {
        listener = new TcpListener(IPAddress.Parse(serverIp), serverPort);
    }
 
    public void StartServer()
    {
        Debug.Log("[Server] Started Server!");
        listener.Start();
 
        StartCoroutine(AcceptConnections());
        StartCoroutine(AcceptMessages());
    }
 
    public void StopAcceptingConnections()
    {
        StopCoroutine(AcceptConnections());
    }
 
    /// <summary>
    /// I would send the scores to the players here, to display on the UI
    /// </summary>
    private void SendMessageToClients(string message)
    {
        for (int i = 0; i < connectedClients.Count; i++)
        {
            // TODO: Send data to all clients of each others scores
            // Data I need: Usernames, scores.
            //connectedClients[i].GetStream().Write();
        }
    }
 
    /// <summary>
    /// Accept any pending connection requests
    /// </summary>
    private IEnumerator AcceptConnections()
    {
        while (true)
        {
            if (listener.Pending() == true)
            {
                TcpClient client = listener.AcceptTcpClient();
                StreamReader clientSr = new StreamReader(client.GetStream());
 
                connectedClients.Add(client);
                connectedClientReaders.Add(clientSr);
            }
 
            yield return null;
        }
    }
 
    /// <summary>
    /// Read any incoming messages
    /// </summary>
    private IEnumerator AcceptMessages()
    {
        while (true)
        {
            for (int i = 0; i < connectedClients.Count; i++)
            {
                string message = connectedClientReaders[i].ReadLine();
 
                if (string.IsNullOrEmpty(message) == false)
                {
                    OnNetworkMessageRecieved(connectedClients[i], message);
                }
            }
 
            yield return null;
        }
    }
 
    private void OnNetworkMessageRecieved(TcpClient client, string message)
    {
        Debug.Log("[Server] Message Recieved: " + message);
    }
}
