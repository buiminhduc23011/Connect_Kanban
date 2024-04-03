const Modbus = require('jsmodbus');
const net = require('net');

// Tạo socket kết nối đến thiết bị Modbus TCP
const socket = new net.Socket();

// Địa chỉ của thiết bị Modbus TCP
const host = "127.0.0.1";
const port = 502;

// Địa chỉ đơn vị Modbus
const unitId = 1; // Thay đổi đơn vị Modbus tùy theo thiết bị cụ thể

// Tạo client Modbus TCP
const client = new Modbus.client.TCP(socket, unitId);

// Thiết lập kết nối đến thiết bị Modbus TCP
socket.connect({host, port});

// Khi kết nối được thiết lập thành công
socket.on('connect', function () {
    console.log('Connected to Modbus TCP device');
    // Đọc coils từ địa chỉ 0 với độ dài 13
    client.readHoldingRegisters(0, 13).then(function (resp) {
        console.log('Registers:', resp.response.body.coils); // In ra giá trị của các coils
        socket.end(); // Đóng kết nối sau khi đọc xong
    }).catch(function (err) {
        console.error('Error:', err); // In ra lỗi nếu có
        socket.end(); // Đóng kết nối nếu có lỗi
    });
});

// Xử lý sự kiện lỗi nếu có
socket.on('error', function (err) {
    console.error('Socket error:', err);
});
