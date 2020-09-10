using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaDeliveryLib.Enums
{
    public enum OrderStatus
    {
        /// <summary>
        /// Подтвержден
        /// <para>Провалидирован системой службы доставки</para>
        /// </summary>
        APPROVED,
        /// <summary>
        /// Запрос на отмену
        /// <para>Временный статус, затем заказ переходит в CANCELLED</para>
        /// </summary>
        CANCEL_REQUEST,
        /// <summary>
        /// Отменен
        /// <para>Заказ был отменен</para>
        /// </summary>
        CANCELLED,
        /// <summary>
        /// Адрес изменен
        /// <para>Адрес был изменен службой доставки (например, по причине недоступности точки выдачи)</para>
        /// </summary>
        CHANGED_ADDRESS,
        /// <summary>
        /// Проверка
        /// <para>Временный статус - после создания заказа (CREATED) выполняется проверка возможности его доставки в выбранную точку. Затем заказ переходит в APPROVED или REJECTED</para>
        /// </summary>
        CHECKING,
        /// <summary>
        /// Скомплектован на складе
        /// <para>Скомплектован (сформирован мешок)</para>
        /// </summary>
        COMPLECTED_IN_WAREHOUSE,
        /// <summary>
        /// Создан
        /// <para>При получении соответствующего заказа и создании его в системе</para>
        /// </summary>
        CREATED,
        /// <summary>
        /// Истекает срок хранения
        /// <para>Истекает срок хранения в точке выдачи (клиент не забрал заказ). Заказ находится в данном статусе сутки, затем переходит в UNCLAIMED</para>
        /// </summary>
        EXPIRING,
        /// <summary>
        /// Выдан
        /// <para>Выдан клиенту (клиент забрал посылку из постамата или пункта выдачи)</para>
        /// </summary>
        PICKED_UP,
        /// <summary>
        /// Размещен в ячейку на складе
        /// <para>Груз размещен в ячейке сортировки на складе</para>
        /// </summary>
        PLACED_IN_CONSOLIDATION_CELL_IN_WAREHOUSE,
        /// <summary>
        /// Размещен в точке выдачи
        /// <para>Размещен в конечной точке выдачи</para>
        /// </summary>
        PLACED_IN_POSTAMAT,
        /// <summary>
        /// Предсортировка
        /// <para>Предсортировка. Этот статус приходит не всегда, так как эта процедура на складе не является обязательной.</para>
        /// </summary>
        PRESORTED,
        /// <summary>
        /// Проблема
        /// <para>Груз утерян, испорчен, принимается решение о ее дальнейшем пути</para>
        /// </summary>
        PROBLEM,
        /// <summary>
        /// Готов к изъятию из пункта выдачи
        /// <para>Ожидает изъятия из пункта выдачи (физически находится в точке выдачи)</para>
        /// </summary>
        READY_FOR_WITHDRAW_FROM_PICKUP_POINT,
        /// <summary>
        /// Готов к отгрузке со склада
        /// <para>Мешок с грузом был размещен в зоне отгрузки</para>
        /// </summary>
        READY_TO_BE_SHIPPED_FROM_WAREHOUSE,
        /// <summary>
        /// Принят на складе детально
        /// <para>Груз прошел штучную приемку (после обмера, фотографирования груза и сканирования ШК)</para>
        /// </summary>
        RECEIVED_IN_WAREHOUSE_IN_DETAILS,
        /// <summary>
        /// Отклонен
        /// <para>Не прошел валидацию системы доставки</para>
        /// </summary>
        REJECTED,
        /// <summary>
        /// Отгружен партнеру
        /// <para>Груз был возвращен партнеру</para>
        /// </summary>
        RETURNED_TO_PARTNER,
        /// <summary>
        /// На сортировке на складе
        /// <para>Груз прибыл на сортировку (после сканирования ШК груз попадет в "тележку")</para>
        /// </summary>
        SORTED_IN_WAREHOUSE,
        /// <summary>
        /// Невостребован
        /// <para>Клиент не забрал заказ из точки выдачи, срок хранения его истек и далее, согласно контракту, он будет возвращен или утилизирован.</para>
        /// </summary>
        UNCLAIMED,
        /// <summary>
        /// Утилизирован
        /// <para>Груз был утилизирован после списания</para>
        /// </summary>
        UTILIZED,
        /// <summary>
        /// Ожидает повторную выдачу
        /// <para>Ожидает на складе повторную выдачу</para>
        /// </summary>
        WAITING_FOR_REPICKUP,
        /// <summary>
        /// Изъят из пункта выдачи
        /// <para>Изъят из пункта выдачи для дальнейшей передачи на склад</para>
        /// </summary>
        WITHDRAWN_FROM_PICKUP_POINT

    }
}
