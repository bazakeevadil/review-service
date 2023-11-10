import React from 'react'

const User = () => {
    return (
        <div>
            <div className='user'>
                <div className='user__wrapper'>
                <div className='container'>
                    <p className='user__name'>
                        User email
                    </p>
                    <div className='user__img'>
                        <img src='https://kartinki.pics/uploads/posts/2022-12/1670006834_4-kartinkin-net-p-belii-fon-dlya-avi-vkontakte-4.jpg' />
                    </div>
                    <div className='user__review'>
                        <div className="comments__card">
                            <div className='comments__info'>
                                <div className="comments__text">
                                    Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                                </div>
                                <p className="comments__user">
                                    kikiki lololo
                                </p>
                                <p className="comments__date">12.12.1212</p>
                                <p className="comments__rating">
                                    ✭✭✭
                                </p>

                            </div>
                            <div className='comments__delete'>
                                <img src="https://cdn-icons-png.flaticon.com/512/3405/3405244.png" />
                            </div>

                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
    )
}

export default User