import socketserver
import canopen
import asyncio

# Initialize Nanotec CANopen
network = canopen.Network()
network.connect(bustype='ixxat', channel=0, bitrate=1000000)
node = network.add_node(1,r".\PD2-C4118L1804-E-08.eds")

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

class MyUDPHandler(socketserver.BaseRequestHandler):
    """
    This class works similar to the TCP handler class, except that
    self.request consists of a pair of data and client socket, and since
    there is no connection the client address must be given explicitly
    when sending data back via sendto().
    """

    def handle(self):
        req = self.request[0].strip()
        socket = self.request[1]
        print("{} wrote:".format(self.client_address[0]))
        print(req)
                
        replyMsg = "0"
        socket.sendto(replyMsg, self.client_address)
                
                    
        clientInput = float(req)
        force = round(0 + 400 * clientInput)
        velocity = round(50 + 500 * clientInput)
        print(force)
        
        
async def motor_loop():
    if nanotec_mode == "velocity":
        node.sdo[0x6042].raw = velocity
    elif nanotec_mode == "torque": 
        node.sdo[0x2031].raw = force
    
        
if __name__ == "__main__":
    HOST, PORT = "localhost", 20001
    server = socketserver.UDPServer((HOST, PORT), MyUDPHandler)
    print("UDP server up and listening")
        
    try:
        server.serve_forever()
        loop = asyncio.get_event_loop()
        res = loop.run_until_complete(motor_loop())
    except KeyboardInterrupt:
        print("Terminating...")
    finally:
        loop.close()
        server.shutdown()
        server.server_close()
        network.disconnect()