function load_wmi_actions(query)
  {
   $.ajax({
    url:"/api/wmi-action-search",
    method:"POST",
    data:{query:query},
    success:function(data)
    {
      $("#result").html(data.htmlresponse);
    }
   });
}

function getCookieValue(cookieName) {
    var cookies = document.cookie;
    cookies = cookies.split('; ');

    var separated_cookies = [];
    var result;

    cookies.forEach((cookie) => {
        var name = cookie.split('=')[0];
        var value = cookie.split('=')[1];

        if (cookieName == name) {
            result = value;
        }
    });

    return result;
}

function load_client_id()
  {
   $.ajax({
    url:"/api/clients_modal",
    method:"GET",
    success:function(data)
    {
      $(".modal-body").html(data.htmlresponse);
      $('#clientIdModal').modal('show');
    }
   });
}