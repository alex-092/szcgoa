// JavaScript source code
;
function MakeSelectlist(array) {
    let result = [{ pid: 0, title: "系统根节点", level: 0 }];
    if (array != null) {
        let topmenus = array.filter(e => {
            if (e.menuLevel == 0) { return true }
        });
        topmenus.forEach(function (topitem, topindex) {
            result.push({ pid: topitem.id, title: "├" + topitem.title, level: 1 });
            array.forEach(function (item, index) {
                if (item.pid == topitem.id) {
                    result.push({ pid: item.id, title: "┈┈" + item.title, level: 2 });
                }
            });
        });
    }
    return result;
}