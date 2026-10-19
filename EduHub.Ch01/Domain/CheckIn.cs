
#nullable enable

using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Hình thức ghi nhận check-in.
    /// </summary>
    public enum CheckInMethod
    {
        QRCode,
        Manual
    }

    /// <summary>
    /// Lưu thông tin check-in của một lượt đăng ký.
    /// </summary>
    public class CheckIn
    {
        /// <summary>
        /// Mã định danh của lượt check-in.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Mã định danh của lượt đăng ký liên quan.
        /// </summary>
        public Guid RegistrationId { get; private set; }

        /// <summary>
        /// Thời điểm check-in.
        /// </summary>
        public DateTime CheckedInAt { get; private set; }

        /// <summary>
        /// Hình thức thực hiện check-in.
        /// </summary>
        public CheckInMethod Method { get; private set; }

        private CheckIn(
            Guid id,
            Guid registrationId,
            DateTime checkedInAt,
            CheckInMethod method)
        {
            Id = id;
            RegistrationId = registrationId;
            CheckedInAt = checkedInAt;
            Method = method;
        }

        /// <summary>
        /// Tạo lượt check-in mới sau khi kiểm tra dữ liệu.
        /// </summary>
        public static CheckIn Create(
            Guid registrationId,
            CheckInMethod method)
        {
            if (registrationId == Guid.Empty)
                throw new ArgumentException(
                    "RegistrationId không được để trống.",
                    nameof(registrationId));

            if (!Enum.IsDefined(typeof(CheckInMethod), method))
                throw new ArgumentException(
                    "Hình thức check-in không hợp lệ.",
                    nameof(method));

            return new CheckIn(
                Guid.NewGuid(),
                registrationId,
                DateTime.UtcNow,
                method);
        }

        /// <summary>
        /// Trả về thông tin tóm tắt của lượt check-in.
        /// </summary>
        public string Summary()
        {
            return $"Check-in {Id} | Registration: {RegistrationId} | " +
                   $"Time: {CheckedInAt:yyyy-MM-dd HH:mm:ss} UTC | " +
                   $"Method: {Method}";
        }
    }
}
