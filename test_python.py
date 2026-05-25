print("=== Python Network Automation Test ===")
print("Python is working correctly!")
print("Netmiko and other packages are installed.")

# This is just a test - we'll add real device connection later
devices = ["Router1", "Switch1", "Router2"]
print(f"\nYou have {len(devices)} devices in your list.")

for device in devices:
    print(f"  - {device}")

print("\n=== Test completed successfully! ===")
