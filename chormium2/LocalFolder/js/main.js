


var login = new Vue({
    el: '#login',
    data: {
        username: window.localStorage.getItem('nausernameme'),
        password: ''

    },
  
    methods: {
        ajax_login: function () {
            var self = this;
            $.ajax({
                url: 'https://www.gamesow.com/jsp/login/',
                data: { username: self.username, password: self.password, valid_code: true, game_id: 11, device: 'mini' },
                dataType: "jsonp",
                async: false,
                success: function (data) {
                    if (data.code === 1) {
                        window.localStorage.setItem('nausernameme', self.username);
                        location.href = "https://www.gamesow.com/playgame/11/";
                       
                       
                        //location.href = 'https://www.gamesow.com/member/dologin?referer=https%3A%2F%2Fwww.gamesow.com%2Fplaygame%2F11%2F&l%3Des_es';
                    } else {
                        alert(data.msg);
                    }
                }
            });
        }
    }
});
