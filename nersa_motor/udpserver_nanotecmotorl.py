                                                                                                                                                   # -*- coding: utf-8 -*-
"""
Created on Thu Apr 19 16:45:11 2018

@author: luoqi
"""

import socket
import time
import sys
import random
import canopen
import os


bufferSize  = 1024

# Create a datagram socket
UDPServerSocket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#UDPServerSocket.setblocking(False)
 
# Bind to address and ip
UDPServerSocket.bind(("127.0.0.1", 20001))
print("UDP server up and listening")

 
# Initialize Nanotec CANopen
network = canopen.Network()
network.connect(bustype='ixxat', channel=0, bitrate=1000000)
node = network.add_node(1,r"c:\Users\luoqi\Desktop\Nanotec\eds\eds\PD2-C4118L1804-E-08.eds")

# Listen for incoming datagrams


    
# Read a variable using SDO
device_type = node.sdo[0x1000].raw   

nanotec_mode = "torque"
    
if nanotec_mode == "velocity":
    # Write SDO to change velocity
    node.sdo[0x2300].raw = 0
    node.sdo[0x6060].raw = 2 # 2-Velocity mode; 4-Torque mode
    node.sdo[0x6040].raw = 6
    node.sdo[0x6040].raw = 7
    node.sdo[0x6040].raw = 15
elif nanotec_mode == "torque":
    node.sdo[0x2300].raw = 0
    node.sdo[0x6060].raw = 4
    node.sdo[0x203B][0x01].raw = 300 
    node.sdo[0x6071].raw = 1000
    node.sdo[0x6072].raw = 1000
    node.sdo[0x6087].raw = 500
    node.sdo[0x6040].raw = 6
    node.sdo[0x6040].raw = 7
    node.sdo[0x6040].raw = 15

while(True):
    
    bytesAddressPair = UDPServerSocket.recvfrom(bufferSize)

    message = bytesAddressPair[0]
    address = bytesAddressPair[1]
    
    # Sending a reply to client
    
    bytesToSend = str.encode(str("0"))
    UDPServerSocket.sendto(bytesToSend, address)
                
    clientInput = float(message)
    force = round(0 + 400 * clientInput)
    velocity = round(50 + 500 * clientInput)
    print(force)
    
    if nanotec_mode == "velocity":
        node.sdo[0x6042].raw = velocity
    elif nanotec_mode == "torque": 
        node.sdo[0x2031].raw = force
#
#
#network.disconnect()
#UDPServerSocket.close()  
    

#    
#    # Write SDO to change position       
#    node.sdo[0x2300].raw = 0
#    node.sdo[0x6060].raw = 1
#    node.sdo[0x6087].raw = 200
#    node.sdo[0x607a].raw = 20000
#    node.sdo[0x6040].raw = 6
#    node.sdo[0x6040].raw = 7
#    node.sdo[0x6040].raw = 79
#    node.sdo[0x6040].raw = 95
      
    
#    time.sleep(0.01)
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    