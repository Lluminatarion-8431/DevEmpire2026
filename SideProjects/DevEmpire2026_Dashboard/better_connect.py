from netmiko import ConnectHandler
import getpass

print("=== Python Network Automation - Better Starter ===\n")

devices = [
    {
        "device_type": "cisco_ios",
        "host": "192.168.1.1",
        "username": "admin",
        "password": getpass.getpass("Enter password for 192.168.1.1: "),
        "secret": ""
    }
]

for device in devices:
    print(f"\n{'='*50}")
    print(f"Connecting to {device['host']}...")
    print('='*50)
    
    try:
        connection = ConnectHandler(**device)
        output = connection.send_command("show version")
        print(output)
        connection.disconnect()
        print(f"✓ Successfully connected to {device['host']}")
    except Exception as e:
        print(f"✗ Failed to connect to {device['host']}: {e}")

print("\n=== Script finished ===")
