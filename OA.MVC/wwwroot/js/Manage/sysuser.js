let inTable, exTable,table;
let rolecols = [[ //user表头
    { field: 'rolename', title: '角色名', width: 100, fixed: 'left' },
    { field: 'roledescript', title: '描述', width:130 },
    { field: 'level', title: '级别', width: 70},
    { title: "操作", fixed: 'right', align: 'center', toolbar: '#userbar' },
]];

function GetExclude(array, inarray) {
    return array.filter(roles => {
        let i = true;
        inarray.forEach(item => {
            if (item.id == roles.id) {
                i=false;
            }
        });
        return i;
    });
}