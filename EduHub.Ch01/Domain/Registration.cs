
#nullable enable

using System;

namespace EduHub.Ch01.Domain
{
    /// <summary>
    /// Trạng thái đăng ký tham gia sự kiện.
    /// </summary>
    public enum RegistrationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    /// <summary>
    /// Đại diện cho một đăng ký tham gia sự kiện.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Mã định danh của đăng ký.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Mã định danh thành viên đăng ký.
        /// </summary>
        public Guid MemberId { get; private set; }

        /// <summary>
        /// Mã định danh sự kiện được đăng ký.
        /// </summary>
        public Guid EventId { get; private set; }

        /// <summary>
        /// Thời điểm đăng ký.
        /// </summary>
        public DateTime RegisteredAt { get; private set; }

        /// <summary>
        /// Trạng thái hiện tại của đăng ký.
        /// </summary>
        public RegistrationStatus Status { get; private set; }

        private Registration(
            Guid id,
            Guid memberId,
            Guid eventId,
            DateTime registeredAt,
            RegistrationStatus status)
        {
            Id = id;
            MemberId = memberId;
            EventId = eventId;
            RegisteredAt = registeredAt;
            Status = status;
        }

        /// <summary>
        /// Tạo đăng ký mới ở trạng thái chờ xác nhận.
        /// </summary>
        public static Registration Create(
            Guid memberId,
            Guid eventId)
        {
            if (memberId == Guid.Empty)
                throw new ArgumentException(
                    "MemberId không được để trống.", nameof(memberId));

            if (eventId == Guid.Empty)
                throw new ArgumentException(
                    "EventId không được để trống.", nameof(eventId));

            return new Registration(
                Guid.NewGuid(),
                memberId,
                eventId,
                DateTime.UtcNow,
                RegistrationStatus.Pending);
        }

        /// <summary>
        /// Xác nhận đăng ký nếu chưa bị hủy.
        /// </summary>
        public void Confirm()
        {
            if (Status == RegistrationStatus.Cancelled)
                throw new InvalidOperationException(
                    "Không thể xác nhận đăng ký đã bị hủy.");

            Status = RegistrationStatus.Confirmed;
        }

        /// <summary>
        /// Hủy đăng ký nếu chưa bị hủy trước đó.
        /// </summary>
        public void Cancel()
        {
            if (Status == RegistrationStatus.Cancelled)
                throw new InvalidOperationException(
                    "Đăng ký đã bị hủy trước đó.");

            Status = RegistrationStatus.Cancelled;
        }
    }
}
