NHIỆM VỤ 1 — USER STORIES 
I. USER STORY: SINH VIÊN
● US-01: Đăng ký tham gia Câu lạc bộ
Mô tả User Story: "Là 1 sinh viên, tôi muốn đăng ký tham gia vào một CLB, để tôi trở thành thành viên và tham gia các hoạt động."
Tiêu chí nghiệm thu:
• Trường hợp 1: Đăng ký tham gia thành công
		Có: Sinh viên đã đăng nhập và chưa từng tham gia CLB lập trình.
		Khi: Sinh viên bấm nút “đăng ký tham gia” tại trang chi tiết CLB.
		Thì: Hệ thống gửi yêu cầu đến ban CLB và hiển thị trạng thái “chờ phê duyệt”.
• Trường hợp 2: Tránh đăng ký trùng lặp
		Có: Sinh viên đã gửi yêu cầu tham gia hoặc đã là thành viên CLB.
		Khi: Sinh viên mở lại trang thông tin của CLB đó.
		Thì: Nút “đăng ký tham gia” bị ẩn hoặc đổi thành “đã đăng ký”.
● US-02: Đăng ký tham gia sự kiện
Mô tả User Story: " Là 1 sinh viên, tôi muốn đăng ký tham gia sự kiện do CLB tổ chức, để tôi nhận được vé và mã QR tham dự."
Tiêu chí nghiệm thu:
• Trường hợp 1: Đăng ký sự kiện thành công
		Có: Sự kiện “workshop python” còn chỗ trống.
		Khi: Sinh viên nhấn nút “đăng ký tham gia sự kiện”.
		Thì: Hệ thống xác nhận đăng ký thành công và tạo mã QR code tham dự cho sinh viên.
• Trường hợp 2: Đăng ký khi sự kiện đã hết chỗ
		Có: Sự kiện đã đủ số lượng người đăng ký tối đa.
		Khi: Sinh viên nhấn nút “đăng ký tham gia sự kiện”.
		Thì: Hệ thống thông báo 'Sự kiện đã hết chỗ' và không tạo vé mới.
● US-03: Check-in điểm danh sự kiện
Mô tả User Story: "Là 1 sinh viên, tôi muốn quét mã QR code để check-in tại sự kiện, để xác nhận sự có mặt nhanh chóng và tự động ghi nhận điểm danh."
Tiêu chí nghiệm thu:
• Trường hợp 1: Check-in thành công
		Có: Sinh viên có vé tham dự hợp lệ cho sự kiện đang diễn ra.
		Khi: Sinh viên đưa mã QR cho ban CLB quét.
		Thì: Hệ thống thông báo “Check-in thành công” và tự động lưu lượt tham dự.
• Trường hợp 2: Vé không hợp lệ hoặc đã check-in
		Có: Mã QR của sinh viên đã được check-in trước đó.
		Khi: Thực hiện quét lại mã QR đó.
		Thì: Hệ thống hiển thị thông báo lỗi “mã QR đã được sử dụng”.
II. USER STORY: BAN CLB
● US-04: Tạo sự kiện mới
Mô tả User Story: "Là 1 ban CLB, tôi muốn  tạo sự kiện mới kèm thông tin thời gian, địa điểm, số lượng và mã QR, để sinh viên có thể xem và đăng ký."
Tiêu chí nghiệm thu:
• Trường hợp 1: Tạo sự kiện thành công
		Có: Ban CLB nhập đầy đủ thông tin: Tên sự kiện, thời gian, địa điểm, số lượng giới hạn.
		Khi: Ban CLB nhấn nút “tạo sự kiện”.
		Thì: Hệ thống lưu sự kiện, tự động tạo mã QR check-in và hiển thị sự kiện lên hệ thống.
• Trường hợp 2: Nhập thiếu thông tin bắt buộc
		Có: Ban CLB để trống trường “thời gian” hoặc “địa điểm”.
		Khi: Ban CLB nhấn nút “tạo sự kiện”.
		Thì: Hệ thống báo lỗi và yêu cầu nhập đầy đủ thông tin còn thiếu.
● US-05: Xem danh sách thành viên & Xuất báo cáo
Mô tả User Story: "Là 1 ban CLB, tôi muốn  xem danh sách tham gia và xuất báo cáo điểm danh ra file excel, để đánh giá hiệu quả sự kiện và nộp báo cáo."
Tiêu chí nghiệm thu:
• Trường hợp 1: Xem danh sách điểm danh
		Có: Sự kiện đang diễn ra hoặc đã kết thúc.
		Khi: Ban CLB mở mục “thống kê điểm danh” của sự kiện.
		Thì: Hệ thống hiển thị danh sách sinh viên kèm trạng thái điểm danh (Đã check-in / Vắng).
• Trường hợp 2: Xuất file báo cáo Excel
		Có: Ban CLB đang ở màn hình thống kê điểm danh sự kiện.
		Khi: Ban CLB bấm nút 'Xuất file Excel'.
		Thì: Hệ thống tải xuống file excel chứa đầy đủ dữ liệu điểm danh.
III. USER STORY: ADMIN
● US-06: Quản lý CLB & phê duyệt thành viên
Mô tả User Story: "Là 1 admin, tôi muốn phê duyệt CLB mới và quản lý phân quyền thành viên, để đảm bảo tính hợp lệ của CLB và duy trì an ninh hệ thống."
Tiêu chí nghiệm thu:
• Trường hợp 1: Phê duyệt CLB mới
		Có trước: Có đơn đăng ký thành lập CLB mới ở trạng thái “chờ duyệt”.
		Khi: Admin bấm nút “phê duyệt”.
		Thì: CLB chính thức hoạt động trên EduHub và chuyển người đăng ký thành”ban CLB”.
• Trường hợp 2: Khóa tài khoản thành viên vi phạm
		Có: Admin mở danh sách quản lý người dùng.
		Khi: Admin chọn một tài khoản vi phạm và bấm “khóa tài khoản”.
		Thì: Trạng thái tài khoản chuyển thành “đã khóa” và không thể đăng nhập vào hệ thống.
