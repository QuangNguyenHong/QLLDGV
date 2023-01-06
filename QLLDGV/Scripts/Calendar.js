document.addEventListener('DOMContentLoaded', function () {
    let eventArr = [];

    let eventsTable = document.getElementById("ClassTable");

    let trElems = eventsTable.getElementsByTagName("tr");
    for (let tr of trElems) {
        let tdElems = tr.getElementsByTagName("td");
        let eventObj = {
            id: tdElems[0].innerText,
            title: tdElems[1].innerText,
            daysOfWeek: tdElems[2].innerText,
            startTime: tdElems[3].innerText,
            endTime: tdElems[4].innerText,
            startRecur: tdElems[5].innerText,
            endRecur: tdElems[6].innerText,
            description: tdElems[7].innerText
        };
        eventArr.push(eventObj);
    }

    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prevYear,prev,next,nextYear today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
        },
        initialView: 'dayGridMonth',
        initialDate: new Date(),
        navLinks: true, // can click day/week names to navigate views
        editable: true,
        selectable: true,
        selectMirror: true,
        dayMaxEvents: true, // allow "more" link when too many events
        events: eventArr,
        //eventClick: function (calEvent, jsEvent, view) {
        //    $('#myModal #eventTitle').text(calEvent.title);
        //    var $description = $('<div>');
        //    $description.append($('<p>').html('<b>Từ: </b>' + calEvent.startTime + '<b> - Đến: </b>' + calEvent.endTime));
        //    $description.append($('<p>').html('<b>Giáo viên dạy: </b>' + calEvent.description));
        //    $('#myModal #pDetails').empty().html($description);
        //    $('#myModal').modal();
        //},
    });
    calendar.render();
});
