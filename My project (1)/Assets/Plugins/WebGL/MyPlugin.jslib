mergeInto(LibraryManager.library, {
    OpenPrompt: function (titlePtr, defaultPtr, namePtr) {
        var title = UTF8ToString(titlePtr);
        var defaultText = UTF8ToString(defaultPtr);
        var objName = UTF8ToString(namePtr); // 유니티에서 받은 오브젝트 이름

        var result = window.prompt(title, defaultText);

        if (result !== null) {
            // 전달받은 objName에게 직접 메시지를 보냅니다.
            SendMessage(objName, 'SetInputText', result);
        }
    }
});
